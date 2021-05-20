using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{
	public Slider healthBar;
	public Rigidbody rb;
	float speed = 4;	
	float rotSpeed = 360;
	float rot = 0;
	float gravity = 8;

	Vector3 moveDir = Vector3.zero;
	
	CharacterController controller;
	Animator anim;

	// Start is called before the first frame update
	void Start()
	{
		rb.useGravity = true;   
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update()
	{	
		if(healthBar.value <= 0) return;

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		Movement();
		GetInput();
	}

	void Movement()
	{
		if (!anim.GetBool("attacking") && !anim.GetBool("defending"))
		{
			if(controller.isGrounded)
			{
				// Stopping - not pressing W or S
				if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S))
				{
					anim.SetBool("walking", false);
					anim.SetInteger("condition", 0); // Idle animation

					moveDir = Vector3.zero;
				}

				// Moving forward - pressing W
				if (Input.GetKey(KeyCode.W))
				{
					anim.SetBool("walking", true);
					anim.SetInteger("condition", 1); // walking animation

					moveDir = Vector3.forward;
					moveDir *= speed;
					
					// Running - pressing left shift
					if (Input.GetKey(KeyCode.LeftShift))
					{
						anim.SetBool("walking", false);
						anim.SetBool("running", true);
						anim.SetInteger("condition", 4); // running animation
						moveDir *= 1.5f;
					}

					moveDir = transform.TransformDirection(moveDir);
					
				}

				// Moving backwards - pressing S
				if (Input.GetKey(KeyCode.S))
				{
					anim.SetBool("walking", true);
					anim.SetInteger("condition", 1); // walking animation

					moveDir = Vector3.back;
					moveDir *= speed;
					moveDir = transform.TransformDirection(moveDir);
					
				}

				// Jumping - pressing spacebar
				if (Input.GetKey(KeyCode.Space))
				{
					anim.SetBool("walking", false);
					anim.SetInteger("condition", 0);

					Vector3 jumpDir = Vector3.up * speed;
					moveDir += jumpDir;

					FindObjectOfType<AudioManager>().Play("Jump");
				}

			}
		}

		// Apply rotation
		rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		transform.eulerAngles = new Vector3(0,rot,0);

		// Apply gravity
		moveDir.y -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
	}

	void GetInput()
	{
		if(controller.isGrounded)
		{
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{
				anim.SetBool("walking", false);
				anim.SetBool("running", false);
				// anim.SetInteger("condition", 0); // Idle animation
				moveDir = Vector3.zero;
			}
			// If left mouse is pressed, it'll attack as long as it's not walking
			if (Input.GetMouseButtonDown(0))
			{
				System.Console.Write("Pressed");
				if (!anim.GetBool("attacking"))
				{
					Attack();
					Console.Write("Attacked");
				}
			}
			// If right mouse is pressed, it'll defend as long as it's not walking
			if (Input.GetMouseButton(1))
			{	
				Defend();
			}

			if (Input.GetMouseButtonUp(1))
			{
				anim.SetBool("defending", false);
				anim.SetInteger("condition", 0);
			}
		}
	}

	/* Attacking */

	void Attack()
	{
		// anim.SetTrigger(Animator.StringToHash("Attack01"));
		Console.Write("attack!");
		StartCoroutine(AttackRoutine());
	}
	
	IEnumerator AttackRoutine()
	{
		anim.SetBool("attacking", true);
		anim.SetInteger("condition", 2); // Attacking animation

		yield return new WaitForSeconds(1.25f);
		// anim.SetTrigger(Animator.StringToHash("Attack01"));

		anim.SetInteger("condition", 0);
		anim.SetBool("attacking", false);
	
	}

	/* end of attacking */

	/* Defending */

	void Defend()
	{
		StartCoroutine(DefendRoutine());
	}

	IEnumerator DefendRoutine()
	{
		anim.SetBool("defending", true);
		anim.SetInteger("condition", 3); // Defending animation

		yield return new WaitForSeconds(0.9f);

	}

	/* end of defending */
}
