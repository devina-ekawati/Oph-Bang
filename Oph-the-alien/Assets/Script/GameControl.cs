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
	public GameObject settingsButton;
	public GameObject homeButton;
	public GameObject pausedScreenGameplay;
	public GameObject buttonItem1;
	public GameObject buttonItem2;
	public GameObject buttonItem3;
	public GameObject buttonItem4;
	public GameObject scoreMenu;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public GameObject scoreTime;
	public GameObject scoreEnemy;
	public GameObject scoreItem;
	public GameObject scoreCoin;
	public GameObject scoreTimeTextBox;
	public GameObject scoreEnemyTextBox;
	public GameObject scoreItemTextBox;
	public GameObject scoreCoinTextBox;
	public GameObject scoreReplay;
	public GameObject scoreHome;
	public GameObject scoreShare;
	public Text scoreTimeText;
	public Text scoreEnemyText;
	public Text scoreItemText;
	public Text scoreCoinText;

	float totalTimeElapsed = 0;
	int position;
	bool paused = false;
	GameObject[] fixedObjects;
	AudioSource fxSound;

	public float healthBarWidth = 0.35f;
	public float maxHealth = 100f;
	public float health = 100f;
	public int score = 0;
	public int enemyKilled = 0;
	public int itemObtained = 0;
	public bool allowLaunchWeapon = true;
	float lastWeaponLaunched;
	private int curWeaponType = 1; //weapon yg sedang dipake (dari weapon yg dipilih)
	public int curWeaponID = 0; //id weapon (dari semua weapon)

	// Use this for initialization
	void Start () {
		//WeaponManager.Instance.SpawnWeapon(curWeaponType);
		hideMenu ();
		hideScoreMenu ();
		Time.timeScale = 1;
        position = 0;
		fixedObjects = GameObject.FindGameObjectsWithTag("Fixed");
		fxSound = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("sound") == 0) {
			fxSound.Stop ();
		}
		alien.GetComponent<Animator> ().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		//if(allowLaunchWeapon)
			//WeaponManager.Instance.SpawnWeapon(curWeaponType);
		if (isGameOver)
		{
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.LoadLevel("personal");
			}
			return;
		}
		time.text = "" + (int)totalTimeElapsed;

		if(alien.GetComponent<Animator> ().enabled == true){
			if(totalTimeElapsed - lastWeaponLaunched > 0.4){
				alien.GetComponent<Animator> ().enabled = false;
			}
		}

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
				Debug.Log("Spawn Weapon");
				if(Input.GetTouch(0).phase == TouchPhase.Began && allowLaunchWeapon){
					alien.GetComponent<Animator> ().enabled = true;
					WeaponManager.Instance.SpawnWeapon(curWeaponType);
					allowLaunchWeapon = false;
					lastWeaponLaunched = totalTimeElapsed;
					curWeaponType = 0;
				}
			}
		}

		if (paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1; 

		if (health <= 0) {
			isGameOver = true;
			int star = 0;
			if (score > 50) {
				star = 1;
			} else if (score > 100) {
				star = 2;
			} else if (score > 200) {
				star = 3;
			}
			int coin = enemyKilled * 3 + (int)totalTimeElapsed * 2;
			PlayerPrefs.SetInt ("coin",PlayerPrefs.GetInt ("coin") + coin);
			showScoreMenu (star, (int)totalTimeElapsed, enemyKilled, itemObtained, coin);
		}
	}

	public void useItem (int id){
		curWeaponType = id;
		switch (id) {
			case 1:
				buttonItem1.SetActive(false);
				break;
			case 2:
				buttonItem2.SetActive(false);
				break;
			case 3:
				buttonItem3.SetActive(false);
				break;
			case 4:
				buttonItem4.SetActive(false);
				break;
		}
	}

	public void pauseGame () {
		resumeButton.SetActive (true);
		restartButton.SetActive (true);
		settingsButton.SetActive (true);
		homeButton.SetActive (true);
		pausedScreenGameplay.SetActive (true);
		paused = true;
	}

	public void hideMenu () {
		GameObject[] pauseObjects = GameObject.FindGameObjectsWithTag ("PauseMenu");
		for (int i = 0; i < pauseObjects.Length; i++) {
			pauseObjects [i].SetActive (false);
		}
		Debug.Log ("lengthz" + pauseObjects.Length);
	}

	public void hideScoreMenu () {
		GameObject[] pauseObjects = GameObject.FindGameObjectsWithTag ("ScoreMenu");
		for (int i = 0; i < pauseObjects.Length; i++) {
			pauseObjects [i].SetActive (false);
		}
		Debug.Log ("lengthz" + pauseObjects.Length);
	}

	public void showScoreMenu (int star, int time, int enemy, int item, int coin) {
		scoreMenu.SetActive(true);
		if(star>=1)
			star1.SetActive(true);
		if(star>=2)
			star2.SetActive(true);
		if(star>=3)
			star3.SetActive(true);
		scoreTime.SetActive(true);
		scoreEnemy.SetActive(true);
		scoreItem.SetActive(true);
		scoreCoin.SetActive(true);
		scoreTimeTextBox.SetActive(true);
		scoreEnemyTextBox.SetActive(true);
		scoreItemTextBox.SetActive(true);
		scoreCoinTextBox.SetActive(true);
		scoreReplay.SetActive(true);
		scoreHome.SetActive(true);
		scoreShare.SetActive(true);
		scoreTimeText.text = time.ToString();
		scoreEnemyText.text = enemy.ToString();
		scoreItemText.text = item.ToString();
		scoreCoinText.text = coin.ToString();
	}

	public void resumeGame () {
		hideMenu ();
		paused = false;
	}

	public void restartGame () {
		hideMenu ();
		Application.LoadLevel ("Battle");
	}

	public void goToHome () {
		hideMenu ();
		Application.LoadLevel ("personal");
	}

	public void goToSettings () {
		//Not implemented
	}

}
