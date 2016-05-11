using UnityEngine;
using System.Collections;

public class OpeningStoryController : MonoBehaviour {
    public GameObject[] openingStory;

	// Use this for initialization
	void Start () {
        StartCoroutine(ChangeOpeningSceneFunction());
	}
	
	// Update is called once per frames
	void Update () {
        
	}

    IEnumerator ChangeOpeningSceneFunction()
    {
        for (int i = 0; i < 23; i++)
        {
            for (int j = 0; j < i; j++)
            {
                openingStory[j].SetActive(false);
            }
            
            openingStory[i].SetActive(true);
            yield return new WaitForSeconds(1);
            
        }
    }

}
