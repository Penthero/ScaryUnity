using UnityEngine;
using System.Collections;

public class Grindstone : MonoBehaviour {

	public float durabilityRepairPercent = 1.0f;
	public float durabilityRepair = 0.0f;
	public GUISkin guiSkin;

	private Sword sword;
	private WeaponHandler weaponHandler;
	private bool inRange = false;

	// Use this for initialization
	void Start () {
		weaponHandler = GameObject.Find ("InformationHandler").GetComponent<WeaponHandler> ();
		sword = weaponHandler.Weapons [2].GetComponent<Sword> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange) {
			if (Input.GetKeyDown ("e")) {
				if(durabilityRepairPercent > 0.0f)
					sword.alterDurability(sword.MaxDurability * durabilityRepairPercent);
				else
					sword.alterDurability(durabilityRepair);
			}
			
		}
	}

	void OnGUI ()
	{
		if(inRange)
		{
			GUI.skin = guiSkin;
			GUI.Label(new Rect (Screen.width/2-50, Screen.height/2-55, 170, 50), "Press E to use grindstone");
			
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		inRange = true;
		
	}
	void OnTriggerExit (Collider other)
	{
		inRange = false;
		
	}
}
