using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public Button pauseText;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseMenu = pauseMenu.GetComponent<Canvas>();
		pauseText = pauseText.GetComponent<Button>();
		pauseMenu.enabled = false;
	}
	
	public void PausePress() {
		Time.timeScale = 0;
		pauseMenu.enabled = true;
		pauseText.enabled = false;
	}
	
	public void ResumePress() {
		Time.timeScale = 1;
		pauseMenu.enabled = false;
		pauseText.enabled = true;
	}
	public void ExitGame() {
		Application.LoadLevel("Menu");
	}
}
