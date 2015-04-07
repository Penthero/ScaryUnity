using UnityEngine;
using System.Collections;

public class WeaponDamage : MonoBehaviour {

	public int damage = 20;
	public Animator anim;

	GameObject player;                          // Reference to the player GameObject.
	CompleteProject.PlayerHealth playerHealth;                  // Reference to the player's health.

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerHealth = player.GetComponent<CompleteProject.PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player && anim.GetBool("attack"))
		{
			playerHealth.TakeDamage (damage);
		}
	}
}
