using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float sensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if(Input.GetKey(GameManager.Instance.forward)) {
            transform.position += transform.forward / 2;
        }
        if(Input.GetKey(GameManager.Instance.backward)) {
            transform.position += -transform.forward / 2;
        }
        if(Input.GetKey(GameManager.Instance.left)) {
            transform.position += -transform.right / 2;
        }
        if(Input.GetKey(GameManager.Instance.right)) {
            transform.position += transform.right / 2;
        }

        //FPS camera
        // rotX = Input.GetAxis ("Mouse X") + sensitivity;
        // rotY = Input.GetAxis ("mouse Y") + sensitivity;   
        // transform.Rotate (0, rotX, 0);

    }
}
