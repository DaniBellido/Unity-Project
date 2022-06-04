//The code in this script that just runs on collision is entirely my own.
// With the exception of the WaitingToRespawn() function which was implemented following a Youtube tutorial by GDTitans,
//https://www.youtube.com/watch?v=mBn7ZIB5Zhw
// which is directly related to the Game Manager script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource dieFX;
    public AudioSource spikeFX;
    public AudioSource waterFX;
    public Animator animPlayer;
    PlayerController player;

    public void OnTriggerEnter(Collider player) 
    {

        if (this.gameObject.tag == "Spike")
        {
            spikeFX.Play();
        }

        if (this.gameObject.tag == "Water")
        {
            waterFX.Play();

        }

        if (player.gameObject.tag == "Player")
        {

            GameManager.instance.SubstractLife();
            animPlayer.SetBool("isPlayerDeath", true);
            dieFX.Play();
            StartCoroutine(WaitingToRespawn());
        }

    
    }

    public IEnumerator WaitingToRespawn()
    {
        yield return new WaitForSeconds(7);
        animPlayer.SetBool("isPlayerDeath", false);
        GameManager.instance.ReturnToTheLastCheckpoint();
    }




}
