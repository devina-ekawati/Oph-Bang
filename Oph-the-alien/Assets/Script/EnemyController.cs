using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(startPosition.x, startPosition.y, startPosition.z + 0.01f);
	}
}
