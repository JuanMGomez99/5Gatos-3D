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

	void OnTriggerEnter(Collider other)
	{
		healthBar.value -= 10;

		if(healthBar.value <= 0)
		{
			anim.SetBool("is_dead", true);
			rb.isKinematic = true;
			rb.detectCollisions = false;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
