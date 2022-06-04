//The code in this script that just runs on collision is entirely my own.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollision : MonoBehaviour
{
    public AudioClip lifeFX;
    public Transform cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            GameManager.instance.AddLife();
            AudioSource.PlayClipAtPoint(lifeFX, cam.transform.position);
            Destroy(gameObject);
        }
    }

}
