using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
    int selected_scene;
    public float speed = 0.3F;
    GameObject player;
    GameObject[] selections;
    // Use this for initialization
    void Start()
    {
        selected_scene = 1;
        selections = GameObject.FindGameObjectsWithTag("selection");
        //player = GameObject.Find("selections");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;


            if (touchDeltaPosition.x > 6.0f)
            {
                if (selected_scene > 1){
                    for (int i = 0; i < selections.Length; i++)
                    {
                        GameObject obj = selections[i];
                        obj.transform.Translate(new Vector3(4.0f, 0.0f, 0.0f));
                    }
                    System.Threading.Thread.Sleep(100);
                    selected_scene--;
                }
            }
            else if (touchDeltaPosition.x < -6.0f)
            {
                if (selected_scene < 3){
                    for (int i = 0; i < selections.Length; i++)
                    {
                        GameObject obj = selections[i];
                        obj.transform.Translate(new Vector3(-4.0f, 0.0f, 0.0f));
                    }
                    System.Threading.Thread.Sleep(100);
                    selected_scene++;
                }
            }

            /*for (int i = 0; i < selections.Length; i++)
            {
                GameObject obj = selections[i];
                if ((touchDeltaPosition.x > 6.0f) && (selected_scene>1))
                //if ((touchDeltaPosition.x > 6.0f))
                {
                    
                    
                }
                else if((touchDeltaPosition.x < -6.0f) && (selected_scene<3)){ 
                //else if((touchDeltaPosition.x < -6.0f)){ 
                    obj.transform.Translate(new Vector3(-4.0f, 0.0f, 0.0f));
                    System.Threading.Thread.Sleep(100);
                    selected_scene++;
                }
                
            }*/
            
            
                //player.transform.Translate(new Vector3(touchDeltaPosition.x * speed, 0.0f, 0.0f));

        }
    }
}