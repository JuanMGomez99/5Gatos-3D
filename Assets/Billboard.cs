using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Billboard class that contains the UI objects so they are looking at the main camera all the time
*/
public class Billboard : MonoBehaviour
{
	public Transform cam;

	void LateUpdate()
	{
		transform.LookAt(transform.position + cam.forward);	
	}
}
