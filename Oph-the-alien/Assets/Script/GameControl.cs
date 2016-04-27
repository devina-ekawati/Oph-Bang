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

	bool paused = false;
	GameObject[] fixedObjects;

	int position;
	float totalTimeElapsed = 0;
	public float health = 100f;
	// Use this for initialization
	void Start () {
		resumeButton.SetActive (false);
		restartButton.SetActive (false);
		Time.timeScale = 1;
        position = 0;
		fixedObjects = GameObject.FindGameObjectsWithTag("Fixed");
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver)
		{
			return;
		}
		time.text = "" + (int)totalTimeElapsed;

		float lifebarWidth = 0.35f  * (health/100f);
		float lifebarHeight = lifeBar.transform.localScale.y;
		float lifebarThick = lifeBar.transform	.localScale.z;
		lifeBar.transform.localScale = new Vector3(lifebarWidth,lifebarHeight,lifebarThick);
		float lostHealth = 100f - health;
		//lifeBar.transform.position(-0.00175f*lostHealth,0,0);
		totalTimeElapsed += Time.deltaTime;

		/*int i = 0;
	    while (i < Input.touchCount) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), -Vector2.up);

            Debug.Log("TAP !");

            if (hit.collider != null) {
				health = 0;
                if(hit.collider.tag=="Enemy")
				{
					health -= 10f;
                    Debug.Log("HIT BOMB! ");
					break;
                }
            }
			++i;
		}*/

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
				WeaponManager.Instance.SpawnWeapon();
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


	public void pauseGame(){
		resumeButton.SetActive (true);
		restartButton.SetActive (true);
		Debug.Log ("pause game");
		paused = true;
	}

	public void resumeGame(){
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
