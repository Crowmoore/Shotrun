using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Volume : MonoBehaviour {

	public static float sfxVolume;
	public static float musicVolume;

	// Use this for initialization
	void Start () {
		SetSFXVolume();
		SetMusicVolume();
	}
	private void SetSFXVolume() {
		sfxVolume = GameObject.Find("SoundSlider").GetComponent<Slider>().value;
	}
	private void SetMusicVolume() {
		musicVolume = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
	}
	public void OnSoundValueChange(float newValue) {
		sfxVolume = newValue;
	}
	public void OnMusicValueChange(float newValue) {
		musicVolume = newValue;
		GameObject.Find("Music").GetComponent<AudioSource>().volume = musicVolume;
	}
}
