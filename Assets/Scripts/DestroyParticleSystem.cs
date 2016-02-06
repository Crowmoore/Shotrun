using UnityEngine;
using System.Collections;

public class DestroyParticleSystem : MonoBehaviour {

	private float timeToDie = 3;

	void Start () {
		Destroy(gameObject, timeToDie);
	}

}
