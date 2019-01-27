using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(carrying){
            carry(carriedObject);
            checkDrop();
        } else {
            pickup();
        }
    }

    void carry(GameObject o) {
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup(){
        if(Input.GetKeyDown(KeyCode.E)){
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                Debug.Log(p);
                if(p != null) {
                    carrying = true;
                    carriedObject = p.gameObject;
                }
            }
        }
    }

    void checkDrop(){
        if(Input.GetKeyUp(KeyCode.E)){
            dropObject();
        } else if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.nearCow){
            Debug.Log("The cow ate the apple");
            carrying = false;
            Destroy(carriedObject);
            carriedObject = null;

        }
    }
    void dropObject(){
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;

    }
}
