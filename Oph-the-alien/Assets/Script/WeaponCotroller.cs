using UnityEngine;
using System.Collections;

public class WeaponCotroller : MonoBehaviour {

	private Vector3 startPosition;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		StartCoroutine(MoveWeaponFunction());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator MoveWeaponFunction()
	{
		yield return new WaitForSeconds(0.05f);
		MoveWeapon();
		StartCoroutine(MoveWeaponFunction());
	}
	
	void MoveWeapon()
	{
		transform.Translate(0,0.02f, 0.3f);
	}
	
}
