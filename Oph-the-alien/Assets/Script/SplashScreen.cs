using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	public float timer = 1f;
	public string levelToLoad = "Startgame";
	public GameObject myParentPanel;
    private Texture2D fadeOutTexture;
    public float fadeSpeed = 10f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;
    //private bool finish = false;

	// Use this for initialization
	void Start () {
        fadeOutTexture = new Texture2D(1, 1);
        fadeOutTexture.SetPixel(0, 0, Color.black);
        fadeOutTexture.Apply();
		
	}

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color temp = GUI.color;
        temp.a = alpha;
        GUI.color = temp;

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

        if (alpha == 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }

        
    }

}
