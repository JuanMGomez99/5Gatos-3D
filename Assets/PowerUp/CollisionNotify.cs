using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionNotify : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider collider) 
	{
        	Debug.Log(collider.gameObject.name);

        	if (collider.gameObject.name == "DogPolyart") {
            		gameObject.SetActive(false);
	        }
	}
}
