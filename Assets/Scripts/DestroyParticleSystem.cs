using UnityEngine;
using System.Collections;

public class DestroyParticleSystem : MonoBehaviour {

	void Start () {
		Destroy(gameObject, 3);
	}

}
