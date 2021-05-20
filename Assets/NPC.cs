using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    NPC class that contains the behaivour of the npc object
*/
public class NPC : MonoBehaviour
{
	public Transform player;
	public float rotSpeed = 0.1f; 
	public float movSpeed = 0.04f;  
	public Animator anim;
	public Slider healthBar;

	private float nextAttack = 0.0f;
	private int attackCount = 1;
	private float attackRange = 1.8f;
	public float attackRate = 3.0f;
	public int attacks = 1;
	public int range = 10;
	// private Collider weapon;

	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		attackCount = attacks;
	}

	// Update is called once per frame
	void Update()
	{	
		// if the nps is dead do nothing
		if(healthBar.value <= 0) return;

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);

		// Change npc behaivour if the player is near and inside the visible range
		if(Vector3.Distance(player.position, this.transform.position) < range && angle < 90)
		{
			direction.y = 0;

			// Make the npc looks in the player direction 
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed);

			anim.SetBool("is_idle", false);
			// if the player is outside attack range walk towards it
			if(direction.magnitude > attackRange)
			{
				this.transform.Translate(0,0,movSpeed);
				anim.SetBool("is_walking", true);
				anim.SetBool("is_attacking", false);
			}
			// Attack player
			else if (Time.time > nextAttack)
			{
				anim.SetBool("is_attacking", true);
				anim.SetBool("is_walking", false);
				attackCount -= 1;
				if (attackCount == 0)
				{
					nextAttack = Time.time + attackRate;
					attackCount = attacks;
				}
				else
				{
					nextAttack = Time.time;
				}
			}
			else
			{
				anim.SetBool("is_idle", true);
				anim.SetBool("is_attacking", false);
				anim.SetBool("is_walking", false);
			}
		}
		else
		{
			anim.SetBool("is_idle", true);
			anim.SetBool("is_attacking", false);
			anim.SetBool("is_walking", false);
		}
	}
}
