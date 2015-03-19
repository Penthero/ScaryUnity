using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

	private bool isFirst = true;

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFirst) {
			GameObject.Find ("InformationHandler").SetActive (false);
			isFirst = false;
		}
	}
}
