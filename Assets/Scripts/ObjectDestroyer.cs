using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {
	
	void OnBecameInvisible() {
		Destroy(gameObject, 3);
		Debug.Log("Destroyed " + gameObject.name);
	}
}
