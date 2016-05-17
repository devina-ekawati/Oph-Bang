using UnityEngine;
using System.Collections;

public class PoofManager : MonoBehaviour {

	public GameObject[] poofs;

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
		for(int i=0; i < poofs.Length; i++)
			Instantiate(poofs[i], pos, Quaternion.identity);
	}

}
