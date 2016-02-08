﻿using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * speed);
	}
}
