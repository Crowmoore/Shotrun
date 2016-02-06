using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public LayerMask collisionMask;

	public Transform bulletTrailPrefab;
	public Transform muzzleFlashPrefab;

	private float minFlashSize = 2.6f;
	private float maxFlashSize = 3.2f;
	private float flashTimeToDie = 0.05f;
	private float paused = 0;
	private int leftButton = 0;
	private AudioSource source;
	private Transform gunPoint;

	void Awake () {
		//source = GetComponent<AudioSource>();
		FindGunPoint();
	}
	private void FindGunPoint() {
		gunPoint = transform.FindChild("Gunpoint");
		if(gunPoint == null) {
			Debug.LogError("No gunpoint found");
		}
	}
	void Update () {
		if(Input.GetMouseButtonDown(leftButton) && Time.timeScale != paused) {
			Shoot();
		}
	}

	public void Shoot() {
		//source.Play();
		CreateBullet();
		CreateFlashEffect();
	}
	private void CreateBullet() {
		Instantiate(bulletTrailPrefab, gunPoint.position, gunPoint.rotation);
	}
	void CreateFlashEffect() {
		Transform flashInstance = Instantiate(muzzleFlashPrefab, gunPoint.position, gunPoint.rotation) as Transform;
		flashInstance.parent = gunPoint;
		float size = Random.Range(minFlashSize, maxFlashSize);
		flashInstance.localScale = new Vector2(size, size);
		Destroy(flashInstance.gameObject, flashTimeToDie);
	}
}
