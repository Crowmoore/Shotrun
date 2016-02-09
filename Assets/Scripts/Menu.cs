using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	
	public Canvas confirmationCanvas;
	public Canvas optionsCanvas;
	public Button startButton;
	public Button optionsButton;
	public Button quitButton;
	public Button backButton;

	private bool show = true;
	private bool hide = false;
	// Use this for initialization
	void Start () {
		SetOptionsCanvas();
		SetConfirmationCanvas();
		SetStartButton();
		SetQuitButton();
		ConfirmationMenu(hide);
		OptionsMenu(hide);
	}
	public void OnBackButtonPress() {
		OptionsMenu(hide);
		QuitButton(show);
		OptionsButton(show);
		StartButton(show);
	}
	public void OnQuitButtonPress() {
		ConfirmationMenu(show);
		QuitButton(hide);
		OptionsButton(hide);
		StartButton(hide);
	}
	public void OnOptionsButtonPress() {
		OptionsMenu(show);
		QuitButton(hide);
		OptionsButton(hide);
		StartButton(hide);
	}
	public void OnNoButtonPress() {
		ConfirmationMenu(hide);
		QuitButton(show);
		OptionsButton(show);
		StartButton(show);
	}
	public void OnYesButtonPress() {
		Application.Quit();
	}
	private void ConfirmationMenu(bool state) {
		confirmationCanvas.enabled = state;
	}
	private void OptionsMenu(bool state) {
		optionsCanvas.enabled = state;
	}
	private void QuitButton(bool state) {
		quitButton.enabled = state;
	}
	private void OptionsButton(bool state) {
		optionsButton.enabled = state;
	}
	private void StartButton(bool state) {
		startButton.enabled = state;
	}
	private void SetConfirmationCanvas() {
		confirmationCanvas = confirmationCanvas.GetComponent<Canvas>();
	}
	private void SetOptionsCanvas() {
		optionsCanvas = optionsCanvas.GetComponent<Canvas>();
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