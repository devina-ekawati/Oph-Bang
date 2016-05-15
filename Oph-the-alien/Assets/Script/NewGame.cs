using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGame : MonoBehaviour {
	public InputField name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayGame(){
		PlayerPrefs.SetString ("PlayerName",name.text);
		Application.LoadLevel ("OpeningStory");
		PlayerPrefs.SetInt ("PlayerDiamond",0);
		PlayerPrefs.SetInt ("PlayerMoney",0);
	}
}
