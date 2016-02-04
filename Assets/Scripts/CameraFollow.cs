using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	float cameraOffsetX = 5.5f;
	float cameraOffsetY = 1.5f;
	
	void Start () {
		target = GameObject.Find ("Player").transform;
	}

	void LateUpdate () {
		if(target != null) {
			transform.position = new Vector3(target.position.x + cameraOffsetX, target.position.y + cameraOffsetY, transform.position.z);
		}
		else {
			Debug.LogError("No player found");
		}
	}
}
