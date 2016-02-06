using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseCanvas;
	public Button pauseButton;

	private float paused = 0;
	private float playing = 1;
	private bool show = true;
	private bool hide = false;
	// Use this for initialization
	void Start () {
		SetPauseCanvas();
		SetPauseButton();
		Menu(hide);
	}
	
	public void OnPauseButtonPress() {
		SetTimeScale(paused);
		Menu(show);
		PauseButton(hide);
	}
	public void OnResumeButtonPress() {
		SetTimeScale(playing);
		Menu(hide);
		PauseButton(show);
	}
	public void OnRetryButtonPress() {
		Application.LoadLevel(Application.loadedLevel);
	}
	public void OnQuitButtonPress() {
		Application.LoadLevel("Menu");
	}
	private void PauseButton(bool state) {
		pauseButton.enabled = state;
	}
	private void Menu(bool state) {
		pauseCanvas.enabled = state;
	}
	private void SetTimeScale(float scale) {
		Time.timeScale = scale;
	}
	private void SetPauseCanvas() {
		pauseCanvas = pauseCanvas.GetComponent<Canvas>();
	}
	private void SetPauseButton() {
		pauseButton = pauseButton.GetComponent<Button>();
	}
}