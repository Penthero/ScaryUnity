using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public bool isQuit = false;
	public bool isContinue = false;

	private GameObject informationHandler;
	private InformationHandler infoHandler;
	private Text text;

	void Awake() {
		informationHandler = GameObject.Find ("InformationHandler");
		infoHandler = informationHandler.GetComponent<InformationHandler> ();
	}

	// Use this for initialization
	void Start () {
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
			Application.LoadLevel(2);				//If you click on other button it loads game!
		}else {
			infoHandler.updateInformationData(2);
			informationHandler.SetActive(true);
			Application.LoadLevel(2);				//If you click on other button it loads game!
		}
		
	}

	void Update() {

	}
}
