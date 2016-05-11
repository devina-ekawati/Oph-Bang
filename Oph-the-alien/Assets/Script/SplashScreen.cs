using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	public float timer = 1f;
	public string levelToLoad = "Startgame";
	public GameObject myParentPanel;
	// Use this for initialization
	void Start () {
		//StartCoroutine ("DisplayScene");
	}

	/*IEnumerator DisplayScene() {
		float alpha = myParentPanel.alpha;
		for (float t = 0.0f; t < 1.0f; t += 0.01f)
		{
			myParentPanel.alpha = Mathf.Lerp(alpha,1,t);
		}
		yield return new WaitForSeconds(timer);
		for (float t = 0.0f; t < 0.5f; t -= 0.01f)
		{
			myParentPanel.alpha = Mathf.Lerp(alpha,1,t);
		}
		Application.LoadLevel (levelToLoad);
	}*/

}
