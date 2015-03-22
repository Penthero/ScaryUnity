var inRange;

public var guiSkin : GUISkin;
public var levelId : int;

function OnTriggerEnter (c : Collider)
{
	inRange = true;

}
function OnTriggerExit (c : Collider)
{
	inRange = false;

}
function OnGUI ()
{
	if(inRange == true)
	{
		GUI.skin = guiSkin;
		GUI.Label(Rect (Screen.width/2-50, Screen.height/2-55, 120, 50), "Press E to enter");
	
	}

}
function Update ()
{
	if (inRange == true)
	{
		if (Input.GetKeyDown ("e"))
		{
			Application.LoadLevel(levelId);
		
		}
	
	}

}