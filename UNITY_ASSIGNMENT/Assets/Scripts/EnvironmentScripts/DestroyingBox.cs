//The code of this script is part of the Hit() function implemented in the PlayerController.cs
//Any object with this script will call the Attacked function defined in the Hit() function and
//depending on the object tag it will behave in one way or another. (Implementation based on lecture notes)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingBox : MonoBehaviour
{
    //public GameObject Sword;
    public GameObject BrokenBox;
    public GameObject NewCollectable;
    public AudioSource BoxSFX;

    public void Attacked()
    {
        //if you hit a box

        if (this.gameObject.tag == "Box") 
        {
            Instantiate(BrokenBox, transform.position, transform.rotation);
            BoxSFX.Play();
            Instantiate(NewCollectable, transform.position, NewCollectable.transform.rotation);
            Debug.Log("YOU HAVE HIT A BOX");
            Destroy(gameObject);
           
            
        }

        if (this.gameObject.tag == "Enemy")
        {
            GameManager.instance.PunchSFX();
            Instantiate(NewCollectable, transform.position, NewCollectable.transform.rotation);
            Debug.Log("YOU HAVE HIT THE ENEMY MUSHROOM");
           
            Destroy(gameObject);
            
        }

    }
}
