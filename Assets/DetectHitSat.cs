using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    DetectHitSat class that contains the behaivour of the satelite that triggers the victory scene
*/
public class DetectHitSat : MonoBehaviour
{
	public Slider healthBar;
	public Transform player;
	public Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Equals("weapon_coll"))	
		{
			player = other.gameObject.transform.parent.parent.parent.parent;

			if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
			{
				healthBar.value -= 10;
				
				if(healthBar.value <= 0)
				{
					Invoke("LoadVictory", 3);
				}
			}
		}
	}

	void LoadVictory()
	{
		SceneManager.LoadScene(6);
	}
}
