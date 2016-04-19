using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Enemy")
        {
            Debug.Log(" Health berkurang");
        }
        Destroy(other.gameObject);
    }
}
