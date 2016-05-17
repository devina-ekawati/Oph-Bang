using UnityEngine;
using System.Collections;

public class PoofManager : MonoBehaviour {

	public GameObject poof1;

	private static PoofManager instance;
	public static PoofManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<PoofManager>();
			}
			return instance;
		}
		set { PoofManager.instance = value; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnPoof(Vector3 pos)
	{
		Debug.Log ("spawn poof");
		GameObject newWeapon = (GameObject)Instantiate(poof1, pos, Quaternion.identity);
	}

}
