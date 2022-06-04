//Code based on a Youtube tutorial by Jayanam https://www.youtube.com/watch?v=rO19dA2jksk&t=2s
//This tutorial was offered as a resource for the lectures.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public GameObject Player;
    //The gameObject player becomes a child of this object so the player can be translated with this object. 
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
