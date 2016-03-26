using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
	public float speed = 0.03F;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKey(KeyCode.A)){
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//Vector2 touchDeltaPosition = new Vector2(5,0);
			
			// Move object across XY plane
			if(Camera.current != null)
			{
				Camera.current.transform.Translate(new Vector3(-touchDeltaPosition.x * speed, 0.0f, 0.0f));
				player.transform.Translate(new Vector3(touchDeltaPosition.x * speed, 0.0f, 0.0f));
				                                 
			}
		}
	}
}
