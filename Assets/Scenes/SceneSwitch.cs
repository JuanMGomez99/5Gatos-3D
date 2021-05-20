using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    SceneSwitch class that loads the next scene when a collision happens 
*/
public class SceneSwitch : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
