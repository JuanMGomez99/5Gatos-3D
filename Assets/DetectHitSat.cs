using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectHitSat : MonoBehaviour
{
	public Slider healthBar;
	public Transform player;
	public Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		Debug.Log(this.transform.GetComponent<Collider>());
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("ola1");
		if (other.gameObject.name.Equals("weapon_coll"))
		{
			Debug.Log("ola");
			healthBar.value -= 10;

			if(healthBar.value <= 0)
			{
				Invoke("LoadVictory", 3);
			}
		}
	}

	void LoadVictory()
	{
		SceneManager.LoadScene(6);
	}
}
