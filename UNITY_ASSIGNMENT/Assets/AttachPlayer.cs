using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public GameObject Player;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player)
            {
                Player.transform.parent = transform;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == Player)
            {
                Player.transform.parent = null;
            }
        }

    }

}
