using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectHitPlayer : MonoBehaviour
{
	public Slider healthBar;
	public Transform player;
	Animator anim;
	public Rigidbody rb;

	private float timeElapsed = 2;
	
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		timeElapsed += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject.name.Equals("shpaga_coll") & timeElapsed > 2)
		{
			timeElapsed = 0;
			healthBar.value -= 10;

			if(healthBar.value <= 0)
			{
				anim.SetBool("dead", true);
				rb.isKinematic = true;
				rb.detectCollisions = false;
				Invoke("LoadGameOver", 3);
			}

			string audioName = healthBar.value <= 0 ? "PlayerDeath" : "PlayerHit";
			FindObjectOfType<AudioManager>().Play(audioName);
		}


		if (other.gameObject.name.StartsWith("Pill"))
		{
			healthBar.value += 20;
			FindObjectOfType<AudioManager>().Play("Pill");
		}
	}

	void LoadGameOver()
	{
		SceneManager.LoadScene(5);
	}

}
