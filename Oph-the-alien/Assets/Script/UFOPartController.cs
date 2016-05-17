using UnityEngine;
using System.Collections;

public class UFOPartController : MonoBehaviour {

    private int numUFOPart;
    public GameObject[] UFOPart;

	// Use this for initialization
	void Start () {
        int size = UFOPart.Length;

        numUFOPart = PlayerPrefs.GetInt("UFOPart");
        switch (numUFOPart)
        {
            case 0:
                for (int i = 0; i < size; i++) {
                    UFOPart[i].SetActive(false);
                }
                break;
            case 1:
                for (int i = 0; i < 1; i++)
                {
                    UFOPart[i].SetActive(true);
                }

                for (int i = 1; i < size; i++)
                {
                    UFOPart[i].SetActive(false);
                }
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    UFOPart[i].SetActive(true);
                }

                for (int i = 2; i < size; i++)
                {
                    UFOPart[i].SetActive(false);
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    UFOPart[i].SetActive(true);
                }

                for (int i = 3; i < size; i++)
                {
                    UFOPart[i].SetActive(false);
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    UFOPart[i].SetActive(true);
                }

                for (int i = 4; i < size; i++)
                {
                    UFOPart[i].SetActive(false);
                }
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
