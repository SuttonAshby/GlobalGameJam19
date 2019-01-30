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
            pickupApple();
            pickupCoconut();
            pickupOrange();
        }
    }

    void carry(GameObject o) {
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    // void pickup(){

    // }

    void pickupApple(){
        if(Input.GetKeyDown(GameManager.Instance.pickApple)){
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                // Debug.Log(p);
                // Debug.Log(p.fruitType);
                if(p.fruitType == "apple") {
                    carrying = true;
                    carriedObject = p.gameObject;
                }
            }
        }
    }
    void pickupCoconut(){
        if(Input.GetKeyDown(GameManager.Instance.pickCoconut)){
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                // Debug.Log(p);
                // Debug.Log(p.fruitType);
                if(p.fruitType == "coconut") {
                    carrying = true;
                    carriedObject = p.gameObject;
                }
            }
        }
    }
    void pickupOrange(){
        if(Input.GetKeyDown(GameManager.Instance.pickOrange)){
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            //casts from center of screen
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            //should cast from mouse position
            // Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                // Debug.Log(p);
                // Debug.Log(p.fruitType);
                if(p.fruitType == "orange") {
                    carrying = true;
                    carriedObject = p.gameObject;
                }
            }
        }
    }

    void checkDrop(){
        //letting go of any pick up fruit button drops the object
        if(Input.GetKeyUp(GameManager.Instance.pickApple) || Input.GetKeyUp(GameManager.Instance.pickOrange) || Input.GetKeyUp(GameManager.Instance.pickCoconut)){
            dropObject();
        } else if (Input.GetKeyDown(GameManager.Instance.feedCow) && GameManager.Instance.nearCow && (carriedObject.GetComponent<Pickupable>().fruitType != GameManager.Instance.cowNotEat)){
            carrying = false;
            Destroy(carriedObject);
            carriedObject = null;
        } else if (Input.GetKeyDown(GameManager.Instance.feedSheep) && GameManager.Instance.nearSheep && (carriedObject.GetComponent<Pickupable>().fruitType != GameManager.Instance.sheepNotEat)){
            carrying = false;
            Destroy(carriedObject);
            carriedObject = null;
        } else if (Input.GetKeyDown(GameManager.Instance.feedPig) && GameManager.Instance.nearPig && (carriedObject.GetComponent<Pickupable>().fruitType != GameManager.Instance.pigNotEat)){
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
