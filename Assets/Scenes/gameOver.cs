using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    gameOver class that contains the behaivour of the UI objects on the GameOver Scene
*/
public class gameOver : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
