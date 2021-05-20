using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ShowMsgs class that contains the behaivour of pop up messages
*/
public class ShowMsgs : MonoBehaviour
{
	public GameObject obj; // Canvas with the message 
	
	void Start()
	{
		obj.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		obj.SetActive(true);	// When the player collides activate GameObject
		StartCoroutine("Wait");
	}
		
	IEnumerator Wait()
	{
		// Destroy both the message object and the object that serves as collider 
		yield return new WaitForSeconds(7);	
		Destroy(obj);
		Destroy(gameObject);
	}
}
