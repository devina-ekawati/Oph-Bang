using UnityEngine;
using System.Collections;

public class TouchDisplay : MonoBehaviour {

    int position;
	public GameObject alien;
	// Use this for initialization
	void Start () {
        position = 0;
	}
	
	// Update is called once per frame
	void Update () {
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
