﻿using UnityEngine;
using System.Collections;

public class UFOPartController : MonoBehaviour {

    private int numUFOPart;
    public GameObject[] UFOPart, bar;

	// Use this for initialization
	void Start () {
		numUFOPart = PlayerPrefs.GetInt("UFOPart");
        int size = UFOPart.Length;

		for (int i = 2; i< size; i++) {
			UFOPart[i].SetActive(false);
			bar[i].SetActive(false);
		}
        
        /*switch (numUFOPart)
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
                break;*/
     }

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("personal");
		}
	}

	
}
