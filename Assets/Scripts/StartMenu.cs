using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public Canvas startMenu;
	public Button pauseText;

	Player playerScript;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		startMenu = startMenu.GetComponent<Canvas>();
		pauseText = pauseText.GetComponent<Button>();
		startMenu.enabled = true;
	}
	
	public void GoPress() {
		startMenu.enabled = false;
		Time.timeScale = 1;
	}
}