//Script for the main menu contains only two functions. Option settings have not been implemented
//This implementation is based on a Brackeys tutorial https://www.youtube.com/watch?v=zc8ac_qUXQY&t=549s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
