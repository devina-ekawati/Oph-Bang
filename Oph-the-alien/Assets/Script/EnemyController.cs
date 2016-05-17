using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject GameControl;

	private float speed = 1;
    private Vector3 startPosition;
	public int health = 20;

	float totalTimeElapsed = 0;
	float freezeStart = 0;
	float lastPoisonReduced = 0;
	bool isFreeze = false;
	bool isPoisoned = false;
	public AudioSource hitSound;
	private int fullHealth;

	// Use this for initialization
	void Start () {
		fullHealth = health;
		GameControl = GameObject.Find("Main Camera");
		Time.timeScale = 1;
        startPosition = transform.position;
        StartCoroutine(MoveEnemyFunction());
		hitSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isFreeze) { 
			if((totalTimeElapsed - freezeStart) > 3){//3detik
				isFreeze = false;
			}
		}
		if (isPoisoned) {
			if((totalTimeElapsed - lastPoisonReduced) < 2){//2 detik
				health -= 2;
				lastPoisonReduced = totalTimeElapsed;
			}
		}
	}

    IEnumerator MoveEnemyFunction()
    {
        yield return new WaitForSeconds(0.1f);
		if(!GameControl.GetComponent<GameControl>().isGameOver)
        	MoveEnemy();
        StartCoroutine(MoveEnemyFunction());
    }

    void MoveEnemy()
    {
		if(!isFreeze)
        	transform.Translate(0,-0.02f*speed, -0.3f*speed);
    }

	void OnTriggerEnter(Collider other)
	{

		Debug.Log ("Trigger Collide");
		if (other.tag == "Weapon")
		{
			Debug.Log ("Musuh Kena senjata");
			int weaponID = GameControl.GetComponent<GameControl>().curWeaponID;
			switch(weaponID){
				case 0: //default weapon
					health -= 10;
					break;
				case 1: //jadi lambat
					speed *= 0.8f;
					break;
				case 2: //jadi freeze
					freezeStart = totalTimeElapsed;
					isFreeze = true;
					break;
				case 3: //kena poison
					isPoisoned = true;
					lastPoisonReduced = totalTimeElapsed;
					break;
				case 4: //hammer
					health -= 20;
					break;
			}
			hitSound.Play();
			Destroy (other.gameObject);
			//Debug.Log ("allow2");
			GameControl.GetComponent<GameControl>().allowLaunchWeapon = true;
		}
		if (health <= 0) {
			StartCoroutine(DelayDestroy());
			Vector3 objectPosition = transform.position;
			PoofManager.Instance.SpawnPoof(objectPosition);
			Destroy (this.gameObject);
			GameControl.GetComponent<GameControl>().score += fullHealth;
			GameControl.GetComponent<GameControl>().enemyKilled += 1;

		}
	}

	IEnumerator DelayDestroy() {
		print(Time.time);
		yield return new WaitForSeconds(1);
		print(Time.time);
	}
}
