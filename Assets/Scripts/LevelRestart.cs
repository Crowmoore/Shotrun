using UnityEngine;
using System.Collections;

public class LevelRestart : MonoBehaviour {
	
	// Update is called once per frame
	public void RestartCurrentLevel () {
		Application.LoadLevel(Application.loadedLevel);
	}
}
