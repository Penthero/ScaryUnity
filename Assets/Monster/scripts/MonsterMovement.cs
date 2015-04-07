using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour
{
	public float deathDistance = 0.0f;
	public float viewAngle = 70.0f;
	public float viewDistance = 20.0f;
	public float hitDistance = 3.0f;
	public float speed = 4.5f;
	public bool isAttacking = false;
	public Animator anim;

	Transform player;               // Reference to the player's position.
	CompleteProject.PlayerHealth playerHealth;      // Reference to the player's health.
	CompleteProject.EnemyHealth enemyHealth;        // Reference to this enemy's health.
	NavMeshAgent nav;               // Reference to the nav mesh agent.
		
		
	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <CompleteProject.PlayerHealth> ();
		enemyHealth = GetComponent <CompleteProject.EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
		nav.speed = speed;
	}
		
	void Update ()
	{
		float angle = Vector3.Angle (player.position - transform.position, transform.forward);
		float distance;
		// If the enemy and the player have health left...
		if (((distance = (player.position - transform.position).magnitude) < viewDistance) && (angle < viewAngle || distance < 5.0f) && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
				// ... attack.
				isAttacking = true;
				nav.SetDestination (player.position);

			if(distance < hitDistance) {
				anim.SetBool("attack", true);
				nav.speed = speed * 0.75f;
			}else{
				anim.SetBool("attack", false);
				nav.speed = speed;
			}
			// ... set the destination of the nav mesh agent to the player.

		}
			// Otherwise...
			else {
			isAttacking = false;
			nav.SetDestination(transform.position);
		}
			
		if (deathDistance > 0.0f && (transform.position - player.position).magnitude > deathDistance) {
			enemyHealth.Kill ();
		}
	}
}