using UnityEngine;
using System.Collections;

public class flashlightAttack : MonoBehaviour {


	public int damage = 40;
	public float attackDelay = 0.5f;

	private Animator anim;
	private bool enemyInRange;
	private bool isAttacking;
	private Collider enemy;
	private float timer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		enemyInRange = false;
		isAttacking = false;
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

		if (Input.GetMouseButtonDown (0)) {
			isAttacking = true;
			anim.ResetTrigger ("Idle");
			anim.SetTrigger ("Attack");
		} else if (Input.GetMouseButtonUp (0)) {
			isAttacking = false;
			anim.ResetTrigger ("Attack");
			anim.SetTrigger ("Idle");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(!enemyInRange  && isAttacking && other.tag == "Enemy" && (timer >= attackDelay))
		{
			// ... the player is in range.
			enemyInRange = true;
			enemy = other;
			timer = 0;
		}
	}

	void OnTriggerExit (Collider other)
	{

	}
}
