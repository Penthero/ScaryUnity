using UnityEngine;
using System.Collections;

public class InformationHandler : MonoBehaviour {

	public Vector3[] startPosition;
	public Vector3[] startRotation;
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
		if (startPosition.Length > id)
			player.transform.position = startPosition [id];
		else
			player.transform.position = Vector3.zero;

		if(startRotation.Length > id)
			player.transform.rotation = Quaternion.Euler (startRotation [id]);
		else
			player.transform.rotation = Quaternion.Euler (Vector3.zero);
	}

}
