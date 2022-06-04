/*This script is purely based on lecture notes and is an extension of PlayerController.cs
 * This script detects the player's weapon colliding with other objects.
 * All of these functions send the necessary data to determine if PlayerController.cs' Hit() function is true or false.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    bool hitting = false;
    string nameHit;
    GameObject objectHit;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag != "Box") return;

        nameHit = other.gameObject.name;

        hitting = true;

        objectHit = other.gameObject;

    }

    public bool isHitting() 
    {
        return hitting;
    }

    public string Name() 
    {
        return nameHit;
    }

    public GameObject ObjectAttacked() 
    {
        return objectHit;
    }

    //reset hit detection

    public void Reset()
    {
        hitting = false;
    }

}
