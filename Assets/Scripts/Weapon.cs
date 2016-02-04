using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public LayerMask collisionMask;

	public Transform bulletTrailPrefab;
	public Transform muzzleFlashPrefab;

	AudioSource source;
	Transform gunPoint;

	void Awake () {
		//source = GetComponent<AudioSource>();
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
		//source.Play();
		Instantiate(bulletTrailPrefab, gunPoint.position, gunPoint.rotation);
		Effect();
	}

	void Effect() {
		Transform flashInstance = Instantiate(muzzleFlashPrefab, gunPoint.position, gunPoint.rotation) as Transform;
		flashInstance.parent = gunPoint;
		float size = Random.Range(2.6f, 3.2f);
		flashInstance.localScale = new Vector2(size, size);
		Destroy(flashInstance.gameObject, 0.05f);
	}
}
