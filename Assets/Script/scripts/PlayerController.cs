using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void Start() {
		count = 0;
		//winText.text = "";
		//setCountText ();
	}

	/*void Update() {

	}*/
	void FixedUpdate() {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);


		//on key space
		if (Input.GetKeyDown (KeyCode.Space)) {
			rigidbody.AddForce(new Vector3(0,300,0));
			Debug.Log ("Space is pressed");
		}

	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive (false);
			++count;
			//setCountText();
			//Destroy(other.gameObject);
		}
	}

	void setCountText() {
		countText.text = "Count: " + count.ToString();

		if (count >= 8) {
			winText.text = "YOU WIN!";
		}
	}

}
