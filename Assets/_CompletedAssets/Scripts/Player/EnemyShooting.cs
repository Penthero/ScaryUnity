using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class EnemyShooting : MonoBehaviour
	{
		public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
		public int damagePerShot = 20;                  // The damage inflicted by each bullet.
		public float range = 100f;                      // The distance the gun can fire.
		public GameObject enemy;
		public float accuracy = 3.0f;
		GameObject player;                          // Reference to the player GameObject.
		//Animator anim;                              // Reference to the animator component.
		Animator enemyAnim;
		//PlayerHealth playerHealth;                  // Reference to the player's health.
		EnemyHealth enemyHealth;                    // Reference to this enemy's health.
		float timer;                                // Timer for counting up to the next attack.
		//added shooting variables
		AudioSource gunAudio;                       // Reference to the audio source.
		Light gunLight;                                 // Reference to the light component.
		ParticleSystem gunParticles;                    // Reference to the particle system.
		LineRenderer gunLine;                           // Reference to the line renderer.
		Ray shootRay;                                   // A ray from the gun end forwards.
		Ray checkRay;
		//more shooting variables
		RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
		int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.


		
		void Awake ()
		{
			// Get the player object
			player = GameObject.FindGameObjectWithTag ("Player");
			// Setting up the references.
			player = GameObject.FindGameObjectWithTag ("Player");
			//playerHealth = player.GetComponent <PlayerHealth> ();
			enemyHealth = enemy.GetComponent<EnemyHealth> ();
			//anim = GetComponent <Animator> ();
			enemyAnim = enemy.GetComponent <Animator> ();

			// Set up the references.
			gunParticles = GetComponent<ParticleSystem> ();
			gunLine = GetComponent <LineRenderer> ();
			gunAudio = GetComponent<AudioSource> ();
			gunLight = GetComponent<Light> ();            
			// Create a layer mask for the Shootable layer.
			shootableMask = LayerMask.GetMask ("Shootable");
			enemyAnim.SetBool ("IsWalking", true);
		}
		
		void OnTriggerEnter (Collider other)
		{

		}
		
		void OnTriggerExit (Collider other)
		{

		}
		
		void Update ()
		{
			// Add the time since Update was last called to the timer.
			timer += Time.deltaTime;
			if (timer > 0.2f)
				gunLine.enabled = false;
			// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
			if (timer >= (timeBetweenAttacks + Random.Range (-timeBetweenAttacks / 2, timeBetweenAttacks / 2)) && ((player.transform.position - transform.position).magnitude < range) && enemyHealth.currentHealth > 0) {
				float angle = Vector3.Angle (player.transform.position - transform.position, transform.forward);

				if (angle < 20.0f) {
					// ... attack.
					Shoot ();
				}
			}
		}
		
		void Shoot ()
		{
			// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
			shootRay.origin = transform.position;
			Vector3 direction = player.transform.position - transform.position;
			shootRay.direction = new Vector3 (direction.x + Random.Range (-accuracy, accuracy)
			                                 , direction.y + Random.Range (-accuracy, accuracy)
			                                 , direction.z + Random.Range (-accuracy, accuracy));
			checkRay.origin = transform.position;
			checkRay.direction = direction;

			if (Physics.Raycast (checkRay, out shootHit, range, shootableMask)) {

				if (!shootHit.collider.CompareTag ("Terrain")) {
					// Reset the timer.
					timer = 0f;
					
					// Play the gun shot audioclip.
					gunAudio.Play ();
					
					// Enable the light.
					gunLight.enabled = true;
					
					// Stop the particles from playing if they were, then start the particles.
					gunParticles.Stop ();
					gunParticles.Play ();
					
					// Enable the line renderer and set it's first position to be the end of the gun.
					gunLine.enabled = true;
					gunLine.SetPosition (0, transform.position);

					// Perform the raycast against gameobjects on the shootable layer and if it hits something...
					if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
						// Try and find an EnemyHealth script on the gameobject hit.
						PlayerHealth playerHealth = shootHit.collider.GetComponent <PlayerHealth> ();
					
						// If the playerHealth component exist...
						if (playerHealth != null) {
							// ... the enemy should take damage.
							playerHealth.TakeDamage (damagePerShot);
						} else {
							EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
						
							// If the playerHealth component exist...
							if (enemyHealth != null) {
								// ... the enemy should take damage.
								enemyHealth.TakeDamage (damagePerShot, shootHit.point);
							}
						}
					
						// Set the second position of the line renderer to the point the raycast hit.
						gunLine.SetPosition (1, shootHit.point);
					}
				// If the raycast didn't hit anything on the shootable layer...
				else {
						// ... set the second position of the line renderer to the fullest extent of the gun's range.
						gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
					}
				}
			} else {

			}
		}
	}
}