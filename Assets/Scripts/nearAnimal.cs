using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearAnimal : MonoBehaviour
{
    public string animal;
    public GameObject menuPanel;

    void Start()
    {
        menuPanel = GameObject.Find("inputpromptBackground");
    }

    void OnTriggerEnter(Collider other){
        // Debug.Log("Object has entered the trigger");

        if(animal == "cow"){
            GameManager.Instance.nearCow = true;
            if(GameManager.Instance.feedCow.ToString() == "None"){
                GameManager.Instance.currentBinding = "feedCow";
                menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
            }
        } else if(animal == "sheep"){
            GameManager.Instance.nearSheep = true;
            if(GameManager.Instance.feedSheep.ToString() == "None"){
                GameManager.Instance.currentBinding = "feedSheep";
                menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
            }
        } else if(animal == "pig"){
            GameManager.Instance.nearPig = true;
            if(GameManager.Instance.feedPig.ToString() == "None"){
                GameManager.Instance.currentBinding = "feedPig";
                menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
            }
        }        
    }
    
    // void OnTriggerStay(Collider other){
    //     Debug.Log("Object is in the trigger");
    // }
    void OnTriggerExit(Collider other){
        // Debug.Log("Object exited the trigger");
        if(animal == "cow"){
            GameManager.Instance.nearCow = false;
        } else if(animal == "sheep"){
            GameManager.Instance.nearSheep = false;
        } else if(animal == "pig"){
            GameManager.Instance.nearPig = false;
        }
    }

}
