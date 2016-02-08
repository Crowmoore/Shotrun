using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	private float timeToDie = 5;

	void OnBecameInvisible() {
		Destroy(gameObject, timeToDie);
		Debug.Log("Destroyed " + gameObject.name);
	}
}
