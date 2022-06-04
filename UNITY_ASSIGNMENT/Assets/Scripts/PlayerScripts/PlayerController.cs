/*
 * This script and its purpose is mostly based on a Youtube tutorial from Brackeys. https://www.youtube.com/watch?v=4HpC--2iowE&t=460s 
 * the code in the update function has remained intact although there is some extension like the Coyote Jump implementation
 * that has been implemented independently.
 * The implementation of the Hit() function is based on past lectures on how to use the Animator where some code has been reused 
 * in the SwordAttack.cs script, which is directly related to the Hit() functions.
 * In the same way, the AttackedByMushroom() function has used the same concept as the one mentioned above but implemented it in the 
 * opposite way, that is, the player being attacked by an enemy and not the player attacking an enemy.
 * The rest of the functions corresponds to animations implemented independently based on lectures where a combination of animations 
 * has been tried to be implemented in the Attack() function without much success.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource attackFX;
    public AudioSource jumpFX;
    public AudioSource dieFX;
    public Animator anim;
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    SwordAttack swordHitTest; //script attached to the sword

    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float jumpGracePeriod;
    public float speed = 6.0f;
    public float turnSmoothTime = 0.1f;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    float turnSmoothVelocity;
    //int timeAttack;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //timeAttack = 0;

        swordHitTest = GetComponentInChildren<SwordAttack>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (isGrounded) 
        {
            lastGroundedTime = Time.time;
            Idle();
        }
     
        //Basic Movement 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 diraction = new Vector3(horizontal, 0f, vertical).normalized;

        if (diraction.magnitude >= 0.1f) 
        {
            float targetAngle = Mathf.Atan2(diraction.x, diraction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

            Walk();
        }

        //Applying gravity to the player 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
       isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        //Jump + Coyote Jump
        if (Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            jumpButtonPressedTime = Time.time;
            jumpFX.Play();
            if (Time.time - lastGroundedTime <= jumpGracePeriod)
            {
                Jump();
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }

        

        //Attack animation
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            attackFX.Play();
            StartCoroutine(Attack());
        }

    }


    public void Hit() 
    {
        if (swordHitTest.isHitting()) 
        {
            swordHitTest.ObjectAttacked().SendMessage("Attacked", null, SendMessageOptions.DontRequireReceiver);

            swordHitTest.Reset();
        }
    }

    public void AttackedByMushroom() 
    {
        //Debug.Log("KILLING");
        anim.SetBool("isPlayerDeath", true);
        dieFX.Play();
        GameManager.instance.SubstractLife();
        StartCoroutine(WaitingToRespawn());   
        
    }


    //Setting animations to the player
    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
       
        if (isGrounded == false) 
        {
            anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
            
        }
        
    }

    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");
        //SOUND

        //timeAttack = 1;

        //if (Input.GetKeyDown(KeyCode.Mouse0)/* && timeAttack == 1*/)
        //{
        //    anim.SetTrigger("Attack2");
        //}

        yield return new WaitForSeconds(5f);

        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);

        //timeAttack = 0;
    }
    public IEnumerator WaitingToRespawn()
    {
        yield return new WaitForSeconds(7);
        anim.SetBool("isPlayerDeath", false);
        GameManager.instance.ReturnToTheLastCheckpoint();
    }


}
