using UnityEngine;
using System.Collections;

public class PreGameLoader : MonoBehaviour {

	public GameObject informationHandler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		informationHandler.SetActive (true);
		Application.LoadLevel (1);
	}
}
