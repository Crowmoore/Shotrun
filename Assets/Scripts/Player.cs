using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller))]
public class Player : MonoBehaviour {

	private float moveSpeed = 8;
	private float gravity = -40;
	private float jumpVelocity = 10;
	private int rightMouseButton = 1;
	private int normal = 1;
	private int high = 2;
	private string jumpPad = "JumpPad";
	private Vector3 velocity;
	private bool isGrounded;
	private float velocityChange;
	private Animation anim;
	private	Controller playerController;

	void Start () {
		InitPlayer();
	}
	void Update () {
		CheckGrounded();
		CheckPlayerInput();
		MovePlayer();
	}
	private void InitPlayer() {
		playerController = GetComponent<Controller>();
		anim = GetComponent<Animation>();
	}
	private void CheckPlayerInput() {
		if(Input.GetMouseButton(rightMouseButton) && isGrounded) {
			Jump(normal);
		}
	}
	private void PlayAnimation(string animation) {
		anim.Play(animation);
	}
	private void MovePlayer() {
		velocity.x = moveSpeed;
		playerController.Move(velocity * Time.deltaTime);
	}
 	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == jumpPad) {
			Jump(high);
			Debug.Log("Jumped high");
		}
	}
	private void Jump(int multiplier) {
			velocity.y = jumpVelocity * multiplier;
			PlayAnimation("jump");
			Debug.Log("Jumped");
	}
	private void CheckGrounded() {
		if(!playerController.collisions.below) {
			isGrounded = false;
			SetVelocityChange();
			ChangeVelocity();
		}
		else {
			isGrounded = true;
			PlayAnimation("run");
		}
	}
	private void SetVelocityChange() {
		velocityChange = gravity * Time.deltaTime;
	}
	private void ChangeVelocity() {
		velocity.y += velocityChange;
	}
}
