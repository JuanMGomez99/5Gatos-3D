using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    DetectHitEnemy class that contains the behaivour of the enemy and how it reacts to collisions
*/
public class DetectHitEnemy : MonoBehaviour
{
	public Slider healthBar;
	public Transform player;
	public int damageReceived = 10;
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
		if (other.gameObject.name.Equals("weapon_coll"))
		{
			player = other.gameObject.transform.parent.parent.parent.parent;

			if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
			{
				healthBar.value -= damageReceived;

				if(healthBar.value <= 0)
				{
					anim.SetBool("is_dead", true);
					rb.isKinematic = true;
					rb.detectCollisions = false;
				}

				string audioName = healthBar.value <= 0 ? "EnemyDeath" : "EnemyHit";
				FindObjectOfType<AudioManager>().Play(audioName);
			}
		}
	}

}
