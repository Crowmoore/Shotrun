using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private AudioSource music;
	private bool isCreated;

	void Awake() {
		if(!isCreated) {
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource>();
		music.volume = Volume.musicVolume;
	}
}
