using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	private float speed = 0.1f;
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
	}
}
