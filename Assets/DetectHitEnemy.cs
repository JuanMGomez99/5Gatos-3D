using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHitEnemy : MonoBehaviour
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
		if (other.gameObject.name.Equals("weapon_coll"))
		{
			healthBar.value -= 10;

			if(healthBar.value <= 0)
			{
				anim.SetBool("is_dead", true);
				rb.isKinematic = true;
				rb.detectCollisions = false;
			}
		}
	}

}
