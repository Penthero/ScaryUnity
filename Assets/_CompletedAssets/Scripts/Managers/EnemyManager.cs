using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {

		public int maxEnemies = 10;
		public float spawnTriggerMaxDistance = 40.0f;
		public float spawnTriggerMinDistance = 0.0f;
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

		private PlayerHealth playerHealth;       // Reference to the player's heatlh.
		private int currentEnemies = 0;
		private GameObject player;

        void Start ()
        {
			player = GameObject.Find("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // If the player has no health left...
			if((playerHealth.currentHealth <= 0f) && (currentEnemies < maxEnemies))
            {
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			float distance = (spawnPoints [spawnPointIndex].position - player.transform.position).magnitude;
			// Makes sure that enemies only spawn when close to a spawnpoint
			if (distance < spawnTriggerMaxDistance && distance > spawnTriggerMinDistance) {
				++currentEnemies;
				// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
				Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			}
        }

		public int DecreseEnemies(int amount) {
			return currentEnemies - amount;
		}

    }
}