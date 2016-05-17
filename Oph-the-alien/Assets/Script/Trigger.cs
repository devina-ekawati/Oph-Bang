using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{


	public GameObject GameControl;
	public GameObject attackedPanel;
	float totalTimeElapsed = 0;
	float lastAttackedTime = 0;
	bool isAttackedPanelActive = false;
    // Use this for initialization
    void Start()
    {
		attackedPanel.SetActive (false);
		Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
		totalTimeElapsed += Time.deltaTime;
		if (isAttackedPanelActive == true) {
			if(totalTimeElapsed - lastAttackedTime > 0.5){
				attackedPanel.SetActive (false);
				isAttackedPanelActive = false;
			}
		}
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Enemy") {
			Debug.Log ("Health berkurang");
			float reduceHealth = 10f;
			GameControl.GetComponent<GameControl>().health = GameControl.GetComponent<GameControl> ().health - reduceHealth;
			float healthBarWidth = GameControl.GetComponent<GameControl>().healthBarWidth;
			float maxHealth = GameControl.GetComponent<GameControl>().maxHealth;
			GameControl.GetComponent<GameControl>().lifeBar.transform.Translate(new Vector3(-reduceHealth/maxHealth * healthBarWidth, 0.0f, 0.0f));
			lastAttackedTime = totalTimeElapsed;
			attackedPanel.SetActive (true);
			isAttackedPanelActive = true;
		} else if (other.tag == "Weapon") {
			Debug.Log ("allow");
			GameControl.GetComponent<GameControl>().allowLaunchWeapon = true;
		}
        Destroy(other.gameObject);
    }
}
