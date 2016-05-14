using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Startgame : MonoBehaviour {
	public GameObject startGame;
	public GameObject confirmation;
	public GameObject loadButton;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("PlayerName")) {
			//loadButton.button.interactiable = false;
		}
		startGame.SetActive (false);
		confirmation.SetActive (false);
	}		
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	public void StartGame(){
		startGame.SetActive (true);
	}
	public void HideStartGame(){
		startGame.SetActive (false);
	}
	public void ExitGame() {
		Application.Quit ();
	}
	public void SettingGame(){

	}
	public void LoadGame(){
		Application.LoadLevel("personal");
	}
	public void NewGame(){
		PlayerPrefs.DeleteKey("PlayerName");
		PlayerPrefs.DeleteKey("PlayerDiamond");
		PlayerPrefs.DeleteKey("PlayerMoney");
		Application.LoadLevel("newgame");
	}
	public void HideConfirmation(){
		confirmation.SetActive (false);
	}
	public void ShowConfirmation(){
		confirmation.SetActive (true);
	}
}
