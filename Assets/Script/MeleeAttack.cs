using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {


	public int damage = 40;
	public float attackDelay = 0.4f;
	public WeaponHandler weaponHandler;
	private bool enemyInRange;
	private Collider enemy;
	private float timer;

	// Use this for initialization
	void Start () {
		enemyInRange = false;
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (enemyInRange) {
			enemyInRange = false;

			//EnemyHealth enemyHealth = enemy.collider.GetComponent<EnemyHealth>();
			CompleteProject.EnemyHealth enemyHealth = enemy.GetComponent <CompleteProject.EnemyHealth> ();

			if(enemyHealth)
				enemyHealth.TakeDamage(damage, new Vector3(0, 0, 0));
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(!enemyInRange  && weaponHandler.isAttacking && other.tag == "Enemy" && (timer >= attackDelay))
		{
			// ... the player is in range.
			Debug.Log ("in Range");
			enemyInRange = true;
			enemy = other;
			timer = 0;
		}
	}

	void OnTriggerExit (Collider other)
	{

	}
}
