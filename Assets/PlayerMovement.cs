using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	float speed = 4;	
	float rotSpeed = 120;
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
		Movement();
		GetInput();
	}

	void Movement()
	{
		if (anim.GetBool("attacking") || anim.GetBool("defending"))
		{
			// Don't move while attacking
			return;
		}
		else
		{
			if(controller.isGrounded)
			{
				// Moving forward - pressing W
				if (Input.GetKey(KeyCode.W))
				{
					anim.SetBool("walking", true);
					anim.SetInteger("condition", 1); // walking animation

					moveDir = new Vector3(0,0,1);
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

					moveDir = new Vector3(0,0,-1);
					moveDir *= speed;
					moveDir = transform.TransformDirection(moveDir);
					
				}

				// Jumping - pressing spacebar
				if (Input.GetKey(KeyCode.Space))
				{
					anim.SetBool("walking", false);
					anim.SetInteger("condition", 0);

					moveDir = new Vector3(0, 1, 0);
					moveDir *= speed;
					moveDir = transform.TransformDirection(moveDir);
				}

				// Stopping - releasing
				if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
				{
					anim.SetBool("walking", false);
					anim.SetInteger("condition", 0); // Idle animation

					moveDir = new Vector3(0,0,0);
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
			// If left mouse is pressed, it'll attack as long as it's not walking
			if (Input.GetMouseButtonDown(0))
			{	
				if(anim.GetBool("walking") || anim.GetBool("running"))
				{
					anim.SetBool("walking", false);
					anim.SetBool("running", false);
					anim.SetInteger("condition", 0); // Idle animation
				}
				if (!anim.GetBool("walking") && !anim.GetBool("running"))
				{
					Attack();
				}
			}
			// If right mouse is pressed, it'll defend as long as it's not walking
			if (Input.GetMouseButtonDown(1))
			{	
				if(anim.GetBool("walking") || anim.GetBool("running"))
				{
					anim.SetBool("walking", false);
					anim.SetBool("running", false);
					anim.SetInteger("condition", 0); // Idle animation
				}
				if (!anim.GetBool("walking") && !anim.GetBool("running"))
				{
					Defend();
				}
			}
		}
	}

	void Attack()
	{
		StartCoroutine(AttackRoutine());
	}

	IEnumerator AttackRoutine()
	{
		anim.SetBool("attacking", true);
		anim.SetInteger("condition", 2); // Attacking animation

		yield return new WaitForSeconds(0.9f);

		anim.SetInteger("condition", 0);
		anim.SetBool("attacking", false);
	}

	void Defend()
	{
		StartCoroutine(DefendRoutine());
	}

	IEnumerator DefendRoutine()
	{
		anim.SetBool("defending", true);
		anim.SetInteger("condition", 3); // Defending animation

		yield return new WaitForSeconds(0.9f);

		anim.SetInteger("condition", 0);
		anim.SetBool("defending", false);
	}
}
