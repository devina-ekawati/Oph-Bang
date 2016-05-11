using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{

	public GameObject GameControl;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
		} else if (other.tag == "Weapon") {
			Debug.Log ("allow");
			GameControl.GetComponent<GameControl>().allowLaunchWeapon = true;
		}
        Destroy(other.gameObject);
    }
}
