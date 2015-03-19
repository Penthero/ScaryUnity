var doorClip : AnimationClip;
var Key : GameObject;
private var Door = false;

function Start () 
{

}

function Update () 
{
	/*if (Input.GetMouseButton(0) && Door == true && Key.active == false)
	{
	GameObject.Find("Door").animation.Play("DoorOpen");
	}
	*/
}

function OnTriggerEnter (theCollider : Collider)
{
	if (theCollider.tag == "Player")
	{
		Door = true;
	}
}

function OnTriggerExit (theCollider : Collider)
{
	if (theCollider.tag == "Player")
	{
		Door = false;
	}
}