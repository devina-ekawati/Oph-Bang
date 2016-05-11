using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Startgame : MonoBehaviour {
	public GameObject startGame;
	// Use this for initialization
	void Start () {
		startGame.SetActive (false);
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
	public void ExitGame() {
		Application.Quit ();
	}
	public void SettingGame(){

	}
	public void LoadGame(){
		Application.LoadLevel("personal");
	}
	public void NewGame(){

	}
}
