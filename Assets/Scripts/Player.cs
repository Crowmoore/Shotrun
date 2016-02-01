using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller))]
public class Player : MonoBehaviour {

	public float moveSpeed = 8;
	public float gravity = -40;
	public float jumpVelocity = 10;
	Vector3 velocity;

	Controller controller;

	void Start () {
		controller = GetComponent<Controller>();
	}

	void Update () {
		if(!controller.collisions.below) {
			velocity.y += gravity * Time.deltaTime;
		}
		if(Input.GetMouseButton(1) && controller.collisions.below) {
			Jump(1);
		}
		velocity.x = moveSpeed;
		controller.Move(velocity * Time.deltaTime);
	}
 	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "JumpPad") {
			Jump(2);
			Debug.Log("Jumped high");
		}
	}
	public void Jump(int multiplier) {
			velocity.y = jumpVelocity * multiplier;
			Debug.Log("Jumped");
	}
}
