using UnityEngine;
using System.Collections;

public class GenerateEnemyController : MonoBehaviour {

    public GameObject enemy;

    private float timeElapsed = 0;
    private float generateCycle = 0.5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateEnemy", 1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void CreateEnemy()
    {
        GameObject temp = (GameObject)Instantiate(enemy);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
    }
}
