using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public float rotationSpeed;
	// Update is called once per frame
	void Update () {
		//new Vector3 (0, 1, 0) * Time.deltaTime
		//transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
		transform.RotateAround(transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime * 10);
	}
}
