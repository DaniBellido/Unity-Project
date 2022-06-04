using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public AudioClip coinFX;
    public Transform cam;
    private void Start()
    {
        //coin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") 
        {
            GameManager.instance.AddCoin();
            AudioSource.PlayClipAtPoint(coinFX, cam.transform.position);
            Destroy(gameObject);
        }
    }

}
