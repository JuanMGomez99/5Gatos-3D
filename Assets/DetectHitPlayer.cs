using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    DetectHitPlayer class that contains the behaivour of the player and how it reacts to collisions
*/
public class DetectHitPlayer : MonoBehaviour
{
	public Slider healthBar;
	public Transform enemy;
	Animator anim;
	public Rigidbody rb;

	public int pillValue = 20;
	public int damageReceived = 10;	

	private float initialHeight;
	private float timeElapsed = 1;

	private float health = 100;
	
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		initialHeight = transform.position.y;
		
		// load health value from memory if it's not the scene 1
		if (!SceneManager.GetActiveScene().name.Equals("scene1"))
		{
			health = PlayerPrefs.GetFloat("PlayerHealth");	
			healthBar.value = health;	
		}
	}

	void Update() {
		if (transform.position.y < (initialHeight - 10)) {
			FindObjectOfType<AudioManager>().Play("PlayerDeath");
			LoadGameOver();
		}
		timeElapsed += Time.deltaTime;
		
		// the health value is stored in memory 
		PlayerPrefs.SetFloat("PlayerHealth", health);
	}

	void OnTriggerEnter(Collider other)
	{
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Defend")) return;	// if the player is on defend no damage is inflicted
  		
		// case: collides with enemy weapon
		if (other.gameObject.name.Equals("shpaga_coll"))
		{
			enemy = other.gameObject.transform.parent.parent.parent;

			if (other.gameObject.name.Equals("shpaga_coll") & timeElapsed >= 1)
			{
				timeElapsed = 0;

				if (enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("musketeer_attack"))
				{
					healthBar.value -= damageReceived;
					health = healthBar.value;

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
		// case: collides with pill
		if (other.gameObject.name.StartsWith("Pill"))
		{
			healthBar.value += pillValue;
			FindObjectOfType<AudioManager>().Play("Pill");
		}
	}

	void LoadGameOver()
	{
		SceneManager.LoadScene(5);
	}

}
