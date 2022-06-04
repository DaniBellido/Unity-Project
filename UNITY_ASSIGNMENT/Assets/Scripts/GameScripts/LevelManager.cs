/*This script just loads the next scene once the player reaches its goal (Win condition)
 * and it can be reusable in every goal object found in any level (currently the game has only one but
 * the Scene Manager gets the current scene and goes to the next one "+1")
 * This has been achieved by myself
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
