using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public Canvas menuCanvas;
	public Button pauseButton;
	
	private float paused = 0;
	private float playing = 1;
	private bool show = true;
	private bool hide = false;
	// Use this for initialization
	void Start () {
		SetTimeScale(paused);
		SetMenuCanvas();
		SetPauseButton();
		Menu(show);
	}
	
	public void OnGoButtonPress() {
		Menu(hide);
		SetTimeScale(playing);
	}
	private void Menu(bool state) {
		menuCanvas.enabled = state;
	}
	private void SetTimeScale(float scale) {
		Time.timeScale = scale;
	}
	private void SetMenuCanvas() {
		menuCanvas = menuCanvas.GetComponent<Canvas>();
	}
	private void SetPauseButton() {
		pauseButton = pauseButton.GetComponent<Button>();
	}
}