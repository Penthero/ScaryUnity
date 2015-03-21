using UnityEngine;
using System.Collections;

public class InformationHandler : MonoBehaviour {

	public Vector3[] startPositions;
	public Vector3[] startRotations;
	public CompleteProject.PlayerHealth playerHealth;
	public Flashlight flashLight;

	private GameObject player;
	//public GameObject hud;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		player = GameObject.Find("Player");
		//player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetStatus() {
		playerHealth.currentHealth = playerHealth.startingHealth;
		flashLight.AlterEnergy ((int)flashLight.maxBatteryLife);
	}

	public void updateInformationData(int id) {
		if (startPositions.Length > id)
			player.transform.position = startPositions [id];
		else
			player.transform.position = Vector3.zero;

		if(startRotations.Length > id)
			player.transform.rotation = Quaternion.Euler (startRotations [id]);
		else
			player.transform.rotation = Quaternion.Euler (Vector3.zero);
	}

}
