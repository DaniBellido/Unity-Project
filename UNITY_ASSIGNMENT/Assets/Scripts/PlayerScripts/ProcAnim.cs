//This script has been implemented with the support of Darrel
//and its only function is to correct a bad relationship between objects.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcAnim : MonoBehaviour
{
    public void Hit() 
    {
        Debug.Log("You have tried to hit something. ");

        this.gameObject.GetComponentInParent<PlayerController>().Hit();
    }


}
