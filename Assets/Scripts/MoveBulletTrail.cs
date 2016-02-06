using UnityEngine;
using System.Collections;

public class MoveBulletTrail : MonoBehaviour {

	private int moveSpeed = 100;
	private float bulletTimeToDie = 0.15f;
	private float wallTimeToDie = 2;
	private int torque = -30;
	private string obstaclesLayer = "Obstacle";
	private string breakablesLayer = "Breakable";
	public Transform bulletHitPrefab;

	private Transform bullet;

	void Awake () {
		FindBullet();
	}
	
	void Update () {
		MoveBullet();
	}

	private void FindBullet() {
		bullet = transform.FindChild("Bullet");
		if(bullet == null) {
			Debug.LogError("No bullet found");
		}
	}
	private void MoveBullet() {
		transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
		Destroy(gameObject, bulletTimeToDie);
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.collider.gameObject.layer == LayerMask.NameToLayer(obstaclesLayer)) {
			Destroy(gameObject);
			CreateHitParticles();
			Debug.Log("Hit obstacle!");
		}
		if(collision.collider.gameObject.layer == LayerMask.NameToLayer(breakablesLayer)) {
			Destroy(gameObject);
			CreateHitParticles();
			ResolveWallHit(collision);
			Debug.Log("Hit breakable!");
		}
	}
	private void ResolveWallHit(Collision2D collision) {
		GameObject wall = collision.collider.gameObject;
		Rigidbody2D wallRb = wall.GetComponent<Rigidbody2D>();
		BoxCollider2D wallCollider = wall.GetComponent<BoxCollider2D>();
		wallRb.AddForce(new Vector2(40, 10), ForceMode2D.Impulse);
		wallRb.AddTorque(torque, ForceMode2D.Impulse);
		wallCollider.enabled = false;
		Destroy(wall, wallTimeToDie);
	}
	private void CreateHitParticles() {
		Instantiate(bulletHitPrefab, bullet.position, bullet.rotation);
	}
}
