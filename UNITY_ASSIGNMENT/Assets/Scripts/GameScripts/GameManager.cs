/*
 *This script is in charge of handling the game's User Interface, 
 *the game over and the change of scenes in case the player's lives reach zero.
 *It is also in charge of handling the player's life and coin count and repositioning the player
 *at the last checkpoint in case of death. 
 *To develop this Game Manager, some concepts seen in the lectures and in different YouTube videos have been mixed and adapted.
 *https://www.youtube.com/watch?v=NYEyXDPKGTw
 *https://www.youtube.com/watch?v=mBn7ZIB5Zhw&t=203s
 *https://www.youtube.com/watch?v=VbZ9_C4-Qbo
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource punchSFX;

    public Text txtCoinsCollected;
    public int totalCoins;
    public Text txtLifeCollected;
    public int totalLives;

    public static Vector3 lastCheckpointPos = new Vector3(24, 6, 5);
    public static bool isGameOver = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;

        totalCoins = 0;
        txtCoinsCollected.text = totalCoins.ToString();

        totalLives = 4;
        txtLifeCollected.text = totalLives.ToString();

    }

    public void AddCoin()
    {
        if (totalCoins == 99)
        {
            totalCoins = 0;
            txtCoinsCollected.text = totalCoins.ToString();
        }
        else
        {
            totalCoins++;
            txtCoinsCollected.text = totalCoins.ToString();
        }

    }

    public void AddLife()
    {
        totalLives++;
        txtLifeCollected.text = totalLives.ToString();
    }

    public void SubstractLife()
    {
       
        totalLives--;
        txtLifeCollected.text = totalLives.ToString();

        GameOver();

    }

    public void ReturnToTheLastCheckpoint()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;
    }

    public void PunchSFX() 
    {
        punchSFX.Play();
    }

    public void GameOver() 
    {
        if (totalLives == 0 && !isGameOver)
        {
            isGameOver = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", 10f);
        }
    }

    public void Restart() 
    {
        totalCoins = 0;
        txtCoinsCollected.text = totalCoins.ToString();

        totalLives = 4;
        txtLifeCollected.text = totalLives.ToString();
        SceneManager.LoadScene(0);
        
    }
}
