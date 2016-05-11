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
        if (other.tag == "Enemy")
        {
            Debug.Log("Health berkurang");
			GameControl.GetComponent<GameControl>().health = GameControl.GetComponent<GameControl>().health - 10f;
        }
        Destroy(other.gameObject);
    }
}
