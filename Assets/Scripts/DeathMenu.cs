using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathMenu : MonoBehaviour {
	
	public Canvas deathMenu;
	public Button pauseText;
	
	// Use this for initialization
	void Start () {
		deathMenu = deathMenu.GetComponent<Canvas>();
		pauseText = pauseText.GetComponent<Button>();
		deathMenu.enabled = false;
	}
	
	public void OpenMenu() {
		Time.timeScale = 0;
		deathMenu.enabled = true;
		pauseText.enabled = false;
	}
	
	public void RetryPress() {
		Application.LoadLevel(Application.loadedLevel);
	}
	public void ExitGame() {
		Application.LoadLevel("Menu");
	}
}