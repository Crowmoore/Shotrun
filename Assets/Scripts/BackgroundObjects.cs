using UnityEngine;
using System.Collections;

public class BackgroundObjects : MonoBehaviour {

	public Transform mountainPrefab1;
	public Transform mountainPrefab2;

	private float minSize = 0.8f;
	private float maxSize = 1.3f;
	private float minSpawnInterval = 3f;
	private float maxSpawnInterval = 7f;
	private float firstCall = 0.5f;
	private float callInterval = 1.5f;
	private Vector3 spawnPosition;
	private Vector3 viewportOffset;
	private Transform mountain;

	void Start () {
		InvokeRepeating("RandomizeSpawnInterval", firstCall, callInterval);
	}
	private void RandomizeSpawnInterval() {
		float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
		Invoke("SpawnMountain", interval);
	}
	private void SpawnMountain() {
		CalculateSpawnPosition();
		CreateNewMountain();
		RandomizeMountainSize();
		Debug.Log("Spawned mountain");
	}
	private void CalculateSpawnPosition() {
		viewportOffset = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0f, 10f));
		spawnPosition = new Vector3(viewportOffset.x, -0.1f, 10f);
	}
	private void CreateNewMountain() {
		mountain = Instantiate(mountainPrefab1, spawnPosition, Quaternion.identity) as Transform;
	}
	private void RandomizeMountainSize() {
		float size = Random.Range(minSize, maxSize);
		mountain.localScale = new Vector2(size, size);
	}
}
