using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public LayerMask collisionMask;

	public Transform bulletTrailPrefab;
	public Transform muzzleFlashPrefab;

	Transform gunPoint;

	void Awake () {
		gunPoint = transform.FindChild("Gunpoint");
		if(gunPoint == null) {
			Debug.LogError("No gunpoint found");
		}
	}

	void Update () {
		if(Input.GetMouseButtonDown(0) && Time.timeScale != 0) {
			Shoot();
		}
	}

	public void Shoot() {
		Instantiate(bulletTrailPrefab, gunPoint.position, gunPoint.rotation);
		Effect();
	}

	void Effect() {
		Transform flashInstance = Instantiate(muzzleFlashPrefab, gunPoint.position, gunPoint.rotation) as Transform;
		flashInstance.parent = gunPoint;
		float size = Random.Range(1.2f, 1.6f);
		flashInstance.localScale = new Vector2(size, size);
		Destroy(flashInstance.gameObject, 0.05f);
	}
}
