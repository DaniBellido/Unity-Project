//This script has been developed following the player's attack concept and
//reusing the same structure to make the enemy "Hit()" function. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingPlayer : MonoBehaviour
{
    bool killing = false;
    string nameHit;
    GameObject player;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag != "Player") return;
        nameHit = other.gameObject.name;
        killing = true;
        player = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        Reset();
    }

    public bool isKilling()
    {
        return killing;
    }
    public string Name()
    {
        return nameHit;
    }
    public GameObject PlayerAttacked()
    {
        return player;
    }
    //reset hit detection
    public void Reset()
    {
        killing = false;
    }
    public void Kill() //this function is created in a particular frame of the action
    {
        if (isKilling())
        {
            PlayerAttacked().SendMessage("AttackedByMushroom", null, SendMessageOptions.DontRequireReceiver);
            Reset();
        }
    }

}
