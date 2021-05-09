using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static int health = 100;
	public GameObject player;
	

	// Start is called before the first frame update
	void Start()
	{	
		InvokeRepeating("ReduceHealth",5,1);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void ReduceHealth()
	{
		health = health - 10;
		if(health <= 0)
		{
			player.GetComponent<Animator>().SetTrigger("dead");	
		}
	}
}
