using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public bool isQuit = false;
	public bool isContinue = false;

	private GameObject informationHandler;
	private Text text;

	// Use this for initialization
	void Start () {
		informationHandler = GameObject.Find("InformationHandler");
		text = GetComponent<Text> ();
	}

	public void OnMouseEnter()
	{
		text.color = Color.red;
	}
	
	public void OnMouseExit()
	{
		text.color = Color.white;
	}
	
	public void OnMouseUp()
	{
		
		if (isQuit) {
			Application.Quit ();					    //If you click on quit aplication quits.
		} else if (isContinue) {
			informationHandler.SetActive(true);
			Application.LoadLevel("Island");				//If you click on other button it loads game!
		}else {
			informationHandler.SetActive(true);
			informationHandler.GetComponent<InformationHandler>().Reset();
			Application.LoadLevel("Island");				//If you click on other button it loads game!
		}
		
	}

	void Update() {

	}
}
