using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(GameManager.Instance.forward)) {
            transform.position += Vector3.forward / 2;
        }
        if(Input.GetKey(GameManager.Instance.backward)) {
            transform.position += -Vector3.forward / 2;
        }
        if(Input.GetKey(GameManager.Instance.left)) {
            transform.position += Vector3.left / 2;
        }
        if(Input.GetKey(GameManager.Instance.right)) {
            transform.position += -Vector3.left / 2;
        }  
            
    }
}
