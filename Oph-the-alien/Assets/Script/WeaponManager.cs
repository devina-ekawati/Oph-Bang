using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	public GameObject GameControl;
	public GameObject weapon;
	/* item 1-n, initiate with Prefabs */
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;
	public GameObject item4;
	public GameObject item5;
	public GameObject item6;
	public GameObject item7;
	public GameObject item8;
	/* selectedItem 1-n, items selected by players */
	private GameObject selectedItem1;
	private GameObject selectedItem2;
	private GameObject selectedItem3;
	private GameObject selectedItem4;
	private int selectedItem1ID;
	private int selectedItem2ID;
	private int selectedItem3ID;
	private int selectedItem4ID;
	public GameObject alien;
	private static WeaponManager instance;
	public static WeaponManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<WeaponManager>();
			}
			return instance;
		}
		set { WeaponManager.instance = value; }
	}

	private GameObject getWeapon (int itemID) {
		switch (itemID) {
			case 1:
				return item1;
				break;
			case 2:
				return item2;
				break;
			case 3:
				return item3;
				break;
			case 4:
				return item4;
				break;
			case 5:
				return item5;
				break;
			case 6:
				return item6;
				break;
			case 71:
				return item7;
				break;
			case 8:
				return item8;
				break;
			default:
				return null;
				break;
		}
	}

	void Start () {
		//item1 = GameObject.Find  PlayerPrefs.GetString("item1");
		PlayerPrefs.SetInt ("item1", 1);
		PlayerPrefs.SetInt ("item2", 2);
		PlayerPrefs.SetInt ("item3", 3);
		PlayerPrefs.SetInt ("item4", 4);
		selectedItem1 = getWeapon (PlayerPrefs.GetInt ("item1"));
		selectedItem1ID = PlayerPrefs.GetInt ("item1");
		selectedItem2 = getWeapon (PlayerPrefs.GetInt ("item2"));
		selectedItem2ID = PlayerPrefs.GetInt ("item2");
		selectedItem3 = getWeapon (PlayerPrefs.GetInt ("item3"));
		selectedItem3ID = PlayerPrefs.GetInt ("item3");
		selectedItem4 = getWeapon (PlayerPrefs.GetInt ("item4"));
		selectedItem4ID = PlayerPrefs.GetInt ("item4");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SpawnWeapon(int type)
	{
		Debug.Log("spawn");

		/*GameObject temp = (GameObject)Instantiate(weapon);
		Vector3 pos = temp.transform.position;
		temp.transform.position = new Vector3(pos.x, pos.y, pos.z);*/

		GameObject curWeapon = null;
		switch(type){
			case 0:
				curWeapon = weapon;
				GameControl.GetComponent<GameControl>().curWeaponID = 0;
				break;
			case 1:
				curWeapon = selectedItem1;
				GameControl.GetComponent<GameControl>().curWeaponID = selectedItem1ID;
				break;
			case 2:
				curWeapon = selectedItem2;
				GameControl.GetComponent<GameControl>().curWeaponID = selectedItem2ID;
				break;
			case 3:
				curWeapon = selectedItem3;
				GameControl.GetComponent<GameControl>().curWeaponID = selectedItem3ID;
				break;
			case 4:
				curWeapon = selectedItem4;
				GameControl.GetComponent<GameControl>().curWeaponID = selectedItem4ID;
				break;
			default:
				break;
		}
		Vector3 pos = alien.transform.position;
		pos.z += 1;
		GameObject newWeapon = (GameObject)Instantiate(curWeapon, pos, Quaternion.identity);
	}
}
