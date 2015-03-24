using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {


	public WeaponHandler weaponHandler;
	public int MaxDamage = 40;
	public int currentDamage = 40;
	public float attackDelay = 0.4f;

	// Use this for initialization
	void Start () {
		currentDamage = MaxDamage;
	}
	
	// Update is called once per frame
	void Update () {
		//EnemyHealth enemyHealth = enemy.collider.GetComponent<EnemyHealth>();
	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is a enemy...
		if(weaponHandler.isAttacking && other.tag == "Enemy")
		{
			CompleteProject.EnemyHealth enemyHealth = other.GetComponent <CompleteProject.EnemyHealth> ();
				
				if(enemyHealth)
					enemyHealth.TakeDamage(currentDamage, new Vector3(0, 0, 0));
		}
	}

	void OnTriggerExit (Collider other)
	{

	}
}
