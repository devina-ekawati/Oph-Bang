using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public GameObject alien;
	public GameObject lifeBar;
	public Text time;
	public bool isGameOver = false;
	public GameObject resumeButton;
	public GameObject restartButton;

	float totalTimeElapsed = 0;
	int position;
	bool paused = false;
	GameObject[] fixedObjects;
	AudioSource fxSound; 

	public float healthBarWidth = 0.35f;
	public float maxHealth = 100f;
	public float health = 100f;
	public bool allowLaunchWeapon = true;
	float lastWeaponLaunched;

	// Use this for initialization
	void Start () {
		resumeButton.SetActive (false);
		restartButton.SetActive (false);
		Time.timeScale = 1;
        position = 0;
		fixedObjects = GameObject.FindGameObjectsWithTag("Fixed");
		fxSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver)
		{
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.LoadLevel("personal");
			}
			return;
		}
		time.text = "" + (int)totalTimeElapsed;

		float lifebarWidth = healthBarWidth  * (health/100f);
		float lifebarHeight = lifeBar.transform.localScale.y;
		float lifebarThick = lifeBar.transform	.localScale.z;
		lifeBar.transform.localScale = new Vector3(lifebarWidth,lifebarHeight,lifebarThick);
		float lostHealth = 100f - health;
		//lifeBar.transform.position(-0.00175f*lostHealth,0,0);
		totalTimeElapsed += Time.deltaTime;

		if  ((totalTimeElapsed - lastWeaponLaunched) > 2) {
			allowLaunchWeapon = true;
		}

		if (!paused) {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
				if (touchDeltaPosition.x > 6.0f) {
					if (position > -1) {
						GetComponent<Camera> ().transform.Translate (new Vector3 (-5.0f, 0.0f, 0.0f));
						alien.transform.Translate (new Vector3 (-5.0f, 0.0f, 0.0f));
						for (int i = 0; i < fixedObjects.Length; i++)
						{
							GameObject obj = fixedObjects[i];
							obj.transform.Translate(new Vector3(-5.0f, 0.0f, 0.0f));
						}
						System.Threading.Thread.Sleep (100);
						position--;
					}
				} else if (touchDeltaPosition.x < -6.0f) {
					if (position < 1) {
						GetComponent<Camera> ().transform.Translate (new Vector3 (5.0f, 0.0f, 0.0f));
						alien.transform.Translate (new Vector3 (5.0f, 0.0f, 0.0f));
						for (int i = 0; i < fixedObjects.Length; i++)
						{
							GameObject obj = fixedObjects[i];
							obj.transform.Translate(new Vector3(5.0f, 0.0f, 0.0f));
						}
						System.Threading.Thread.Sleep (100);
						position++;
					}
				}
			} else if (Input.touchCount > 0) {
				//tembak
				if(Input.GetTouch(0).phase == TouchPhase.Began && allowLaunchWeapon){
					WeaponManager.Instance.SpawnWeapon();
					allowLaunchWeapon = false;
					lastWeaponLaunched = totalTimeElapsed;
				}
			}
		}

		if (paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1; 

		if (health <= 0) {
			isGameOver = true;
		}
	}


	public void pauseGame () {
		resumeButton.SetActive (true);
		restartButton.SetActive (true);
		Debug.Log ("pause game");
		paused = true;
	}

	public void resumeGame () {
		resumeButton.SetActive (false);
		restartButton.SetActive (false);
		Debug.Log ("resume game");
		paused = false;
	}

	public void restartGame(){
		resumeButton.SetActive (false);
		restartButton.SetActive (false);
		Debug.Log ("restart game");
		Application.LoadLevel ("Battle");
	}
}
