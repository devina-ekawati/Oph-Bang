using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private Vector3 startPosition;
	public int health = 20;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        StartCoroutine(MoveEnemyFunction());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator MoveEnemyFunction()
    {
        yield return new WaitForSeconds(0.1f);
        MoveEnemy();
        StartCoroutine(MoveEnemyFunction());
    }

    void MoveEnemy()
    {
        transform.Translate(0,-0.02f, -0.3f);
    }

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Trigger Collide");
		if (other.tag == "Weapon")
		{
			Debug.Log ("Musuh Kena senjata");
			health -= 10;
		}
		if (health <= 0)
			Destroy (this.gameObject);
	}
}
