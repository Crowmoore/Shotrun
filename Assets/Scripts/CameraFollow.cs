using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	float cameraOffsetX = 7.5f;
	float cameraOffsetY = 1.5f;
	
	void Start () {
		target = GameObject.Find ("Player").transform;
	}

	void LateUpdate () {
		transform.position = new Vector3(target.position.x + cameraOffsetX, target.position.y + cameraOffsetY, transform.position.z);
	}
}
