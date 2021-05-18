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


	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Equals("shpaga_coll"))
		{
			healthBar.value -= 10;

			if(healthBar.value <= 0)
			{
				anim.SetBool("dead", true);
				rb.isKinematic = true;
				rb.detectCollisions = false;
				Invoke("LoadGameOver", 3);
			}
		}

		if (other.gameObject.name.Equals("Pill"))
		{
			healthBar.value += 20;
		}
	}

	void LoadGameOver()
	{
		SceneManager.LoadScene(5);
	}

}
