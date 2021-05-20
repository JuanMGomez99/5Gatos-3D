using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    MainMenu class that contains the behaivour for loading or exiting the game
*/
public class MainMenu : MonoBehaviour
{
	public void Start()
	{
		Screen.SetResolution(1920, 1080, true);
	}
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ExitGame()
	{
		//Debug.Log("exit");
		Application.Quit();
	}
}
