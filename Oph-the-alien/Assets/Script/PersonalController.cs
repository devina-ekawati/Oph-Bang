using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PersonalController : MonoBehaviour {
	public GameObject SubMenu, close, shadow;
	private bool showSubMenu = false;
	public Text name, diamond, money;
	public InputField NewName;
	public GameObject [] popup;
	public Sprite []hat, upper, lower, shoes;
	private int popupon;
	public Image [] body;
	public AudioClip backMusic; 
	public GameObject disable;
	AudioSource fxSound; 
	// Use this for initialization
	void Start () {
		popupon = -1;
		SubMenu.SetActive (showSubMenu);
		shadow.SetActive (false);
		name.text = "" + PlayerPrefs.GetString("PlayerName");
		diamond.text = "" + PlayerPrefs.GetInt ("PlayerDiamond");
		money.text = "" + PlayerPrefs.GetInt ("PlayerMoney");
		NewName.text = "" + PlayerPrefs.GetString("PlayerName");

		body[0].sprite = hat[PlayerPrefs.GetInt ("hat")];
		body [1].sprite = upper [PlayerPrefs.GetInt ("upper")];
		body [2].sprite = lower [PlayerPrefs.GetInt ("lower")];
		body [3].sprite = shoes [PlayerPrefs.GetInt ("shoes")];
		Dressing ();

		fxSound = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("sound") == 0) {
			fxSound.Play ();
		}
		for (int i=0; i< popup.Length; i++) {
			popup[i].SetActive(false);
		}
		close.SetActive (false);
	}
	public void SetSound(){
		if (PlayerPrefs.GetInt ("sound")== 1) {
			PlayerPrefs.SetInt ("sound", 0);
			disable.SetActive (false);
			fxSound.Play ();
		}
		else {
			PlayerPrefs.SetInt ("sound", 1);
			disable.SetActive (true);
			fxSound.Stop();
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("Startgame");
		}
	}
	public void ShowSubMenu(){
		if (showSubMenu)
			showSubMenu = false;
		else
			showSubMenu = true;
		SubMenu.SetActive (showSubMenu);
		if (PlayerPrefs.GetInt ("sound")==1)
			disable.SetActive (true);
		else
			disable.SetActive (false);
	}
	public void ShowPopUp(int i){
		Debug.Log (i);
		if (popupon != -1) {
			popup [popupon].SetActive (false);

		}
		popup [i].SetActive (true);
		shadow.SetActive (true);
		popupon = i;
		close.SetActive (true);
	}
	public void HidePopUp(){
		shadow.SetActive (false);
		popup [popupon].SetActive (false);
		popupon = -1;
		close.SetActive (false);
	}
	public void EditName(){
		PlayerPrefs.SetString ("PlayerName",NewName.text);
		name.text = NewName.text;
	}
	public void SetHat(int i){
		PlayerPrefs.SetInt ("hat",i);
		Dressing ();
		HidePopUp ();
	}
	public void SetUpper(int i){
		PlayerPrefs.SetInt ("upper",i);
		Dressing ();
		HidePopUp ();
	}
	public void SetLower(int i){
		PlayerPrefs.SetInt ("lower",i);
		Dressing ();
		HidePopUp ();
	}
	public void SetShoes(int i){
		PlayerPrefs.SetInt ("shoes",i);
		Dressing ();
		HidePopUp ();
	}
	public void Dressing(){
		body [0].sprite = hat[PlayerPrefs.GetInt ("hat")];
		body [1].sprite = upper [PlayerPrefs.GetInt ("upper")];
		body [2].sprite = lower [PlayerPrefs.GetInt ("lower")];
		body [3].sprite = shoes [PlayerPrefs.GetInt ("shoes")];
	}
	public void OpenMap(){
		Application.LoadLevel("SelectScene");
	}



}
