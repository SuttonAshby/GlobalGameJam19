using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Object has entered the trigger");
        GameManager.Instance.nearCow = true;
    }
    
    void OnTriggerStay(Collider other){
        // Debug.Log("Object is in the trigger");
    }
    void OnTriggerExit(Collider other){
        Debug.Log("Object exited the trigger");
        GameManager.Instance.nearCow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
