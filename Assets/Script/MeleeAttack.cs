using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {


	public WeaponHandler weaponHandler;
	public int MaxDamage = 40;
	public int currentDamage = 40;
	public float attackDelay = 0.4f;
	private bool enemyInRange;
	private Collider enemy = null;
	private float timer;

	// Use this for initialization
	void Start () {
		enemyInRange = false;
		timer = 0.0f;
		currentDamage = MaxDamage;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (enemyInRange) {
			enemyInRange = false;

			//EnemyHealth enemyHealth = enemy.collider.GetComponent<EnemyHealth>();
			if(enemy){
				CompleteProject.EnemyHealth enemyHealth = enemy.GetComponent <CompleteProject.EnemyHealth> ();

				if(enemyHealth)
					enemyHealth.TakeDamage(currentDamage, new Vector3(0, 0, 0));
			}
			enemy = null;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is a enemy...
		if(!enemyInRange  && weaponHandler.isAttacking && other.tag == "Enemy" && enemy == null && (timer >= attackDelay))
		{
			// ... the enemy is in range.
			enemyInRange = true;
			enemy = other;
			timer = 0;
		}
	}

	void OnTriggerExit (Collider other)
	{

	}
}
