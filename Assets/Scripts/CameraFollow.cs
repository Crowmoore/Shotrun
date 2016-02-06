using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform target;
	private float cameraOffsetX = 5.5f;
	private float cameraOffsetY = 1.5f;
	
	void Start () {
		SetCameraTarget();
	}

	void LateUpdate () {
		if(target != null) {
			UpdateCameraPosition();
		}
		else {
			Debug.LogError("No player found");
		}
	}
	private void SetCameraTarget() {
		target = GameObject.Find ("Player").transform;
	}
	private void UpdateCameraPosition() {
		transform.position = new Vector3(target.position.x + cameraOffsetX, target.position.y + cameraOffsetY, transform.position.z);
	}
}
