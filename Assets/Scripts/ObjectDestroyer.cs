using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	private float timeToDie = 3;

	void OnBecameInvisible() {
		Destroy(gameObject, timeToDie);
		Debug.Log("Destroyed " + gameObject.name);
	}
}
