﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public GameObject menuPanel;
    public string fruitType;

    void OnTriggerEnter(Collider other){

        if(fruitType == "apple"){
            if(GameManager.Instance.pickApple.ToString() == "None"){
                GameManager.Instance.currentBinding = "pickApple";
                menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                //instantiate apples from this tree
            } else {
                //instantiate apples from this tree
            }
        } else if(fruitType == "coconut"){
            if(GameManager.Instance.pickCoconut.ToString() == "None"){
                GameManager.Instance.currentBinding = "pickCoconut";
                menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                //instantiate coconuts from this tree
            } else {
                //instantiate coconuts from this tree
            }
        } else if(fruitType == "orange"){
            if(GameManager.Instance.pickOrange.ToString() == "None"){
                GameManager.Instance.currentBinding = "pickOrange";
                menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                //instantiate oranges from this tree
            } else {
                //instantiate oranges from this tree
            }
        }
        // Debug.Log("Object has entered the trigger");
    }
    // void OnTriggerStay(Collider other){
        // Debug.Log("Object is in the trigger");
    // }
    // void OnTriggerExit(Collider other){
        // Debug.Log("Object exited the trigger");
    // }
}