using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMsgs : MonoBehaviour
{
	public GameObject obj;
	
	// Start is called before the first frame update
	void Start()
	{
		obj.SetActive(false);
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		obj.SetActive(true);
		StartCoroutine("Wait");
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(7);
		Destroy(obj);
		Destroy(gameObject);
	}
}
