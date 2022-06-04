//This script ends the game automatically in 10 seconds once the demo is finished. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartingGame : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 10f;
    public Text countDowntxt;

    private void Start()
    {
        currentTime = startingTime;
        Invoke("Quit", startingTime);
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDowntxt.text = currentTime.ToString("0");
    }

    public void Quit()
    {
       
        SceneManager.LoadScene(0);

    }



}
