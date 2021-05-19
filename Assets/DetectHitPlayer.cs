using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectHitPlayer : MonoBehaviour
{
	public Slider healthBar;
	public Transform enemy;
	Animator anim;
	public Rigidbody rb;

	private float initialHeight;
	private float timeElapsed = 2;
	
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		initialHeight = transform.position.y;
	}

	void Update() {
		Debug.Log(transform.position.y);
		if (transform.position.y < (initialHeight - 10)) {
			LoadGameOver();
		}
		timeElapsed += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Equals("shpaga_coll"))
		{
			enemy = other.gameObject.transform.parent.parent.parent;

			if (other.gameObject.name.Equals("shpaga_coll") & timeElapsed > 2)
			{
				timeElapsed = 0;
				healthBar.value -= 10;

				if (enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("musketeer_attack"))
				{
					healthBar.value -= 5;

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
			}
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
