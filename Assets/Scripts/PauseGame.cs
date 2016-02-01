using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	bool isPaused;

	public void Pause() {
		if(!isPaused) {
			Time.timeScale = 0;
			isPaused = true;
		} else {
			Time.timeScale = 1;
			isPaused = false;
		}
	}
}
