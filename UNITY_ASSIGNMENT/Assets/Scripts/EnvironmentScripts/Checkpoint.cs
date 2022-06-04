//This is an extension of the GameManager script and it's been extended by myself.
//The checkpoint conecpt developed in the GameManager scipt has been developed following a
//Youtube tutorial by GDTitans https://www.youtube.com/watch?v=mBn7ZIB5Zhw&t=200s
//This scipt detects a collision between this object (a sphere) and the player,
//stores the position in a variable, and change the object behaviour. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform cam;
    Animator anim;
    AudioSource checkpointFX;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        checkpointFX = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") 
        {
            if (GetComponent<Renderer>().material.color != Color.green) 
            {
                checkpointFX.Play();
            }
            GameManager.lastCheckpointPos = transform.position;
            GetComponent<Renderer>().material.color = Color.green;
            //AudioSource.PlayClipAtPoint(checkpointFX, cam.transform.position);
            anim.SetBool("isOn", true);

        }
    }
}
