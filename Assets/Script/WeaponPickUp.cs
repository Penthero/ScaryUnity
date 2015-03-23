using UnityEngine;
using System.Collections;

public class WeaponPickUp : MonoBehaviour {

	public int WeaponType = 0;
	public GUISkin guiSkin;

	private WeaponHandler weaponHandler;
	private bool inRange = false;

	// Use this for initialization
	void Start () {
		weaponHandler = GameObject.Find ("InformationHandler").GetComponent<WeaponHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange)
		{
			if (Input.GetKeyDown ("e"))
			{
				weaponHandler.EquipWeapon(WeaponType);
				Destroy(this);
				
			}
			
		}
	}

	
	void OnGUI ()
	{
		if(inRange)
		{
			GUI.skin = guiSkin;
			GUI.Label(new Rect (Screen.width/2-50, Screen.height/2-55, 120, 50), "Press E to pickup weapon");
			
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
