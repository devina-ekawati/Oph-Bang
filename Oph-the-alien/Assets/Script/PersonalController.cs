﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PersonalController : MonoBehaviour {
	public GameObject SubMenu, close, shadow, confirmation;
	private bool showSubMenu = false;
	public Text name, diamond, money;
	public InputField NewName;
	public Button [] buttonItem, buyItem;
	public GameObject [] popup, itemSelected, bar;
	public Sprite []hat, upper, lower, shoes, item;
	private int popupon, itemNumberSelected;
	public Image [] body, selected;
	public AudioClip backMusic; 
	public GameObject disable;

	AudioSource fxSound; 
	// Use this for initialization
	void Start () {
		itemNumberSelected = 0;
		int temp = PlayerPrefs.GetInt("UFOPart");
		for (int i = temp; i< bar.Length; i++) {
			bar[i].SetActive(false);
		}
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

		DeselectedItem ();

		fxSound = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("sound") == 0) {
			fxSound.Play ();
		}
		for (int i=0; i< popup.Length; i++) {
			popup[i].SetActive(false);
		}
		close.SetActive (false);
	}

	public void DeselectedItem(){
		for(int i=0; i<4; i++){
			itemSelected[i].SetActive(false);
		}
	}

	public void SelectItem(int number){
		itemSelected [itemNumberSelected].SetActive (false);
		itemSelected [number].SetActive (true);
		itemNumberSelected = number;
	}

	public void SetItem(int number){
		buttonItem [itemNumberSelected].image.sprite = item [number];
		//selected [itemNumberSelected].sprite = item [number];
		PlayerPrefs.SetInt ("item"+itemNumberSelected, number);
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
	public void BuyItemConvirmation(){
		confirmation.SetActive (true);
	}
	public void HideItemConfirmation(){
		confirmation.SetActive (false);
	}
	public void Buy(){

	}

	public void UpdateShop(){
		int temp = PlayerPrefs.GetInt("UFOPart");
		for (int i = 0; i< temp; i++) {
			buyItem[i].GetComponentInChildren<Text>().text ="sold";
			//buyItem[i].
			buyItem[i].GetComponent<Button>().interactable = false;

		}
		HideItemConfirmation ();
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
		if (i == 4) {
			UpdateShop ();
		}
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
	public void ShowUfo(){
		Application.LoadLevel ("ufo");
	}


}
