using UnityEngine;
using System.Collections;

public class PoofController : MonoBehaviour {

	float totalTimeElapsed = 0;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		totalTimeElapsed += Time.deltaTime;
		if (totalTimeElapsed >= 2)
			Destroy (this.gameObject);
	}
}
