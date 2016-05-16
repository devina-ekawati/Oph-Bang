using UnityEngine;
using System.Collections;

public class GenerateEnemyController : MonoBehaviour {

    public GameObject enemyBaby;
	public GameObject enemyKidGirl;
	public GameObject enemyBigKid;

    private float timeElapsed = 0;
    private float generateCycle = 5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateEnemy", 1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void CreateEnemy()
    {
		int randomEnemy = ((int)Random.Range(0, 3));
		GameObject enemy = null;
		switch (randomEnemy) {
			case 0:
				enemy = enemyBaby;
				break;
			case 1:
				enemy = enemyKidGirl;
				break;
			case 2:
				enemy = enemyBigKid;
				break;
			default:
				break;
		}
		GameObject temp = (GameObject)Instantiate(enemy);
        Vector3 pos = temp.transform.position;
        int x = ((int)Random.Range(-1, 2)) * 5;
        temp.transform.position = new Vector3(x, pos.y-5, pos.z);        
    }
}
