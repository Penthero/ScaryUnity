using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

	private GameObject informationHandler;

	void Awake() {
		informationHandler = GameObject.Find ("InformationHandler");

	}

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		informationHandler.GetComponent<InformationHandler> ().ResetStatus ();
		informationHandler.SetActive (false);
	}
}
