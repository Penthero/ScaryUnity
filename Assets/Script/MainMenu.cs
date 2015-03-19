using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public bool isQuit = false;

	Text text;

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
		
		if (isQuit)
		{
			Application.Quit();					    //If you click on quit aplication quits.
		}
		else
		{
			Application.LoadLevel("Island");				//If you click on other button it loads game!
		}
		
	}
}
