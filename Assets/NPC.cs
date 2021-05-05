using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC : MonoBehaviour
{
	public Transform player;
	static Animator anim;

	// Start is called before the first frame update
	void Start()
	{
		Console.Write(anim);
		anim = GetComponent<Animator>();
		Console.Write(anim);
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);
		
		// Change npc state if the player is near and inside the visible range
		if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 90)
		{
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
			Attacking(direction);
		}
		else
		{
			anim.SetBool("is_idle", true);
			anim.SetBool("is_walking", false);
			anim.SetBool("is_attacking", false);
		}
	}

	// Attack actions
	void Attacking(Vector3 direction)
	{
		anim.SetBool("is_idle", false);

		if (direction.magnitude > 2)
		{
			this.transform.Translate(0,0,0.05f);
			anim.SetBool("is_walking", true);
			anim.SetBool("is_attacking", false);
		} 
		else
		{
			anim.SetBool("is_attacking", true);
			anim.SetBool("is_walking", false);
		}
	}
}
