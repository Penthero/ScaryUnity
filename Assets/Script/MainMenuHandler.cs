using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

	private GameObject informationHandler;

	void Awake() {
		informationHandler = GameObject.Find ("InformationHandler");

	}

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		informationHandler.GetComponent<InformationHandler> ().ResetStatus ();
		informationHandler.SetActive (false);
	}
}
