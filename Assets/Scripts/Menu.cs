using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	
	public Canvas confirmationCanvas;
	public Button startButton;
	public Button quitButton;

	private bool show = true;
	private bool hide = false;
	// Use this for initialization
	void Start () {
		SetConfirmationCanvas();
		SetStartButton();
		SetQuitButton();
		ConfirmationMenu(hide);
	}
	
	public void OnQuitButtonPress() {
		ConfirmationMenu(show);
		QuitButton(hide);
		StartButton(hide);
	}
	public void OnNoButtonPress() {
		ConfirmationMenu(hide);
		QuitButton(show);
		StartButton(show);
	}
	public void OnYesButtonPress() {
		Application.Quit();
	}
	private void ConfirmationMenu(bool state) {
		confirmationCanvas.enabled = state;
	}
	private void QuitButton(bool state) {
		quitButton.enabled = state;
	}
	private void StartButton(bool state) {
		startButton.enabled = state;
	}
	private void SetConfirmationCanvas() {
		confirmationCanvas = confirmationCanvas.GetComponent<Canvas>();
	}
	private void SetStartButton() {
		startButton = startButton.GetComponent<Button>();
	}
	private void SetQuitButton() {
		quitButton = quitButton.GetComponent<Button>();
	}
	public void StartGame() {
		Application.LoadLevel("test");
	}
}