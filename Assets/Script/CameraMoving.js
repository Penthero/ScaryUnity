#pragma strict

public var anchorPosition : Transform;
public var cameraSpeed : float = 0.1;

function Start () {

}

function Update () {
	
	transform.position = Vector3.Lerp(transform.position,anchorPosition.position,cameraSpeed);
	transform.rotation = Quaternion.Lerp(transform.rotation,anchorPosition.rotation,cameraSpeed);
	

}

function setAnchor(newAnchorPosition : Transform) {
	
	anchorPosition = newAnchorPosition;
}