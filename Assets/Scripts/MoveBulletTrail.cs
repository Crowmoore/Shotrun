using UnityEngine;
using System.Collections;

public class MoveBulletTrail : MonoBehaviour {

	public int moveSpeed = 100;
	public Transform bulletHitPrefab;

	Transform bullet;

	void Awake () {
		bullet = transform.FindChild("Bullet");
		if(bullet == null) {
			Debug.LogError("No bullet found");
		}
	}
	
	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
		Destroy(gameObject, 0.3f);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
			Instantiate(bulletHitPrefab, bullet.position, bullet.rotation);
			Destroy(gameObject);
			Debug.Log("Hit obstacle!");
		}
		if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Breakable")) {
			Instantiate(bulletHitPrefab, bullet.position, bullet.rotation);
			GameObject wall = collision.collider.gameObject;
			Rigidbody2D wallRb = wall.GetComponent<Rigidbody2D>();
			BoxCollider2D wallCollider = wall.GetComponent<BoxCollider2D>();
			wallRb.AddForce(new Vector2(40, 10), ForceMode2D.Impulse);
			wallRb.AddTorque(-30, ForceMode2D.Impulse);
			wallCollider.enabled = false;
			Destroy(gameObject);
			Destroy(wall, 2);
			Debug.Log("Hit breakable!");
		}
	}
}
