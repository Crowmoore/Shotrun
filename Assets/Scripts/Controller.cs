using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider2D))]
public class Controller : MonoBehaviour {

	public LayerMask collisionMask;

	const float skinWidth = .015f;
	private int horizontalRayCount = 4;
	private int verticalRayCount = 4;
	private float horizontalRaySpacing;
	private float verticalRaySpacing;
	private int left = -1;
	private int right = 1;
	private int down = -1;
	private int up = 1;
	private int stopped = 0;

	private BoxCollider2D collider;
	private RaycastOrigins raycastOrigins;
	public CollisionInfo collisions;

	void Start() {
		collider = GetComponent<BoxCollider2D>();
		CalculateRaySpacing();
	}

	public void Move(Vector3 velocity) {
		UpdateRaycastOrigins();
		collisions.Reset();
		if(velocity.x != stopped) {
			HorizontalCollisions(ref velocity);
		}
		if(velocity.y != stopped) {
			VerticalCollisions(ref velocity);
		}
		transform.Translate(velocity);
	}

	void HorizontalCollisions(ref Vector3 velocity) {
		float directionX = Mathf.Sign(velocity.x);
		float rayLength = Mathf.Abs (velocity.x) + skinWidth; 

		for(int i = 0; i < horizontalRayCount; i++) {
			Vector2 rayOrigin = (directionX == left)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);
			
			if(hit) {
				//velocity.x = (hit.distance - skinWidth) * directionX;
				//rayLength = hit.distance;
				collisions.left = directionX == left;
				collisions.right = directionX == right;
				if(collisions.right) {
					PlayerDeath();
					Destroy(gameObject);
				}
			}
		}
	}

	void VerticalCollisions(ref Vector3 velocity) {
		float directionY = Mathf.Sign(velocity.y);
		float rayLength = Mathf.Abs (velocity.y) + skinWidth; 
		for(int i = 0; i < verticalRayCount; i++) {
			Vector2 rayOrigin = (directionY == down)?raycastOrigins.bottomLeft:raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

			if(hit) {
				velocity.y = (hit.distance - skinWidth) * directionY;
				//rayLength = hit.distance;

				collisions.below = directionY == down;
				collisions.above = directionY == up;
				if(collisions.above) {
					PlayerDeath();
					Destroy(gameObject);
				}
			}
		}
	}
	void PlayerDeath() {
		var death = GameObject.Find("DeathMenu").GetComponent<DeathMenu>();
		death.OpenMenu();
	}
	void UpdateRaycastOrigins() {
		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth * -2);

		raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
	}

	void CalculateRaySpacing() {
		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth * -2);

		horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}

	struct RaycastOrigins {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}
	public struct CollisionInfo {
		public bool above, below;
		public bool left, right;

		public void Reset() {
			above = below = false;
			left = right = false;
		}
	}
}
