using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	public GameObject weapon;
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

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SpawnWeapon()
	{
		Debug.Log("spawn");

		/*GameObject temp = (GameObject)Instantiate(weapon);
		Vector3 pos = temp.transform.position;
		temp.transform.position = new Vector3(pos.x, pos.y, pos.z);*/
		Vector3 pos = alien.transform.position;
		pos.z += 1;
		GameObject newWeapon = (GameObject)Instantiate(weapon, pos, Quaternion.identity);
	}
}
