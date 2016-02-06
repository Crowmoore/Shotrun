using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathMenu : MonoBehaviour {

	public Canvas deathCanvas;
	public Button pauseButton;
	
	private float paused = 0;
	private bool show = true;
	private bool hide = false;
	// Use this for initialization
	void Start () {
		SetDeathCanvas();
		SetPauseButton();
		Menu(hide);
	}
	
	public void OpenMenu() {
		SetTimeScale(paused);
		Menu(show);
		PauseButton(hide);
	}
	public void OnRetryButtonPress() {
		Application.LoadLevel(Application.loadedLevel);
	}
	public void OnQuitButtonPress() {
		Application.LoadLevel("Menu");
	}
	private void Menu(bool state) {
		deathCanvas.enabled = state;
	}
	private void PauseButton(bool state) {
		pauseButton.enabled = state;
	}
	private void SetTimeScale(float scale) {
		Time.timeScale = scale;
	}
	private void SetDeathCanvas() {
		deathCanvas = deathCanvas.GetComponent<Canvas>();
	}
	private void SetPauseButton() {
		pauseButton = pauseButton.GetComponent<Button>();
	}
}