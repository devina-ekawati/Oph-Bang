using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public GameObject alien;
	public Text scoreText;
	public Text healthText;

	int position;
	float totalTimeElapsed = 0;
	float score=0f;
	float health=100f;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
        position = 0;
	}
	
	// Update is called once per frame
	void Update () {
		totalTimeElapsed += Time.deltaTime;
		score = totalTimeElapsed;
		scoreText.text= "Score: " + score;
		healthText.text= "Health: " + health;
		int i = 0;
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
		}	
		
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if (touchDeltaPosition.x > 6.0f)
            {
                if (position > -1)
                {
                    GetComponent<Camera>().transform.Translate(new Vector3(-5.0f, 0.0f, 0.0f));
					alien.transform.Translate(new Vector3(-5.0f, 0.0f, 0.0f));
                    System.Threading.Thread.Sleep(100);
                    position--;
                }
            }
            else if (touchDeltaPosition.x < -6.0f)
            {
                if (position < 1)
                {
                    GetComponent<Camera>().transform.Translate(new Vector3(5.0f, 0.0f, 0.0f));
					alien.transform.Translate(new Vector3(5.0f, 0.0f, 0.0f));
                    System.Threading.Thread.Sleep(100);
                    position++;
                }
            }
        }
	}
}
