using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
	public Transform player;
	public float rotSpeed = 0.1f; 
	public float movSpeed = 0.04f;  
	public Animator anim;
	public Slider healthBar;
	private float nextAttack = 0.0f;
	public float attackRate = 3.0f;
	public int attacks = 1;
	private int attackCount = 1;
	public int range = 10;
	private int attackRange = 2;
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
		if(healthBar.value <= 0) return;

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);

		// Change npc behaivour if the player is near and inside the visible range
		if(Vector3.Distance(player.position, this.transform.position) < range && angle < 90)
		{
			direction.y = 0;

			// npc looks in the player direction 
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed);

			anim.SetBool("is_idle", false);
			if(direction.magnitude > attackRange)
			{
				this.transform.Translate(0,0,movSpeed);
				anim.SetBool("is_walking", true);
				anim.SetBool("is_attacking", false);
			}
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
