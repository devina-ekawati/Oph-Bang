using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PersonalController : MonoBehaviour {
	public GameObject SubMenu, close;
	private bool showSubMenu = false;
	public Text name, diamond, money;
	public InputField NewName;
	public GameObject [] popup;
	public Sprite []hat, upper, lower, shoes;
	private int popupon;
	public Image [] body;
	// Use this for initialization
	void Start () {
		popupon = -1;
		SubMenu.SetActive (showSubMenu);
		name.text = "" + PlayerPrefs.GetString("PlayerName");
		diamond.text = "" + PlayerPrefs.GetInt ("PlayerDiamond");
		money.text = "" + PlayerPrefs.GetInt ("PlayerMoney");
		NewName.text = "" + PlayerPrefs.GetString("PlayerName");

		body[0].sprite = hat[PlayerPrefs.GetInt ("hat")];
		body [1].sprite = upper [PlayerPrefs.GetInt ("upper")];
		body [2].sprite = lower [PlayerPrefs.GetInt ("lower")];
		body [3].sprite = shoes [PlayerPrefs.GetInt ("shoes")];
		Dressing ();

		for (int i=0; i< popup.Length; i++) {
			popup[i].SetActive(false);
		}
		close.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ShowSubMenu(){
		if (showSubMenu)
			showSubMenu = false;
		else
			showSubMenu = true;

		SubMenu.SetActive (showSubMenu);
	}
	public void ShowPopUp(int i){
		Debug.Log (i);
		if (popupon != -1)
			popup [popupon].SetActive (false);
		popup [i].SetActive (true);
		popupon = i;
		close.SetActive (true);
	}
	public void HidePopUp(){
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



}
