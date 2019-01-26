using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppleTree : MonoBehaviour
{
    public GameObject menuPanel;    
    void start(){
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Object has entered the trigger");
        if(GameManager.Instance.pickApple.ToString() == "None"){
            menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
        }
    }
    void OnTriggerStay(Collider other){
        // Debug.Log("Object is in the trigger");
    }
    void OnTriggerExit(Collider other){
        // Debug.Log("Object exited the trigger");
    }

    // public void ShowMenu(){
    //     foreach(GameObject g in ShowOnTrigger){
    //         g.setActive(!g.setActive);
    //     }
    // }

}
