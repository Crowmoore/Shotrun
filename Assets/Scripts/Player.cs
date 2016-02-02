using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller))]
public class Player : MonoBehaviour {

	private float moveSpeed = 8;
	private float gravity = -40;
	private float jumpVelocity = 10;
	Vector3 velocity;

	Animation anim;

	Controller playerController;

	void Start () {
		playerController = GetComponent<Controller>();
		anim = GetComponent<Animation>();
		anim.Play("run");
	}

	void Update () {
		if(!playerController.collisions.below) {
			velocity.y += gravity * Time.deltaTime;
		}
		else {
			anim.Play("run");
		}
		if(Input.GetMouseButton(1) && playerController.collisions.below) {
			Jump(1);
		}
		velocity.x = moveSpeed;
		playerController.Move(velocity * Time.deltaTime);
	}
 	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "JumpPad") {
			Jump(2);
			Debug.Log("Jumped high");
		}
	}
	public void Jump(int multiplier) {
			velocity.y = jumpVelocity * multiplier;
			anim.Play("jump");
			Debug.Log("Jumped");
	}
}
