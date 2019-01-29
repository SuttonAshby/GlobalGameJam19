using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public MenuHideControl menuPanel;
    public string fruitType;
    public GameObject spawnee;
    public Vector3 spawnPos;
    private bool canSpawn;
    private float targetTime = 10f;

    void Start()
    {
        menuPanel = GameObject.Find("inputpromptBackground").GetComponent<MenuHideControl>();
    }

    void Update(){
        if(!canSpawn){
           targetTime -= Time.deltaTime;
           if(targetTime <= 0.0f){
               canSpawn = true;
               targetTime = 10f;
           } 
        }

    }


    void OnTriggerEnter(Collider other){
        Debug.Log("Object has entered the trigger");
        if(fruitType == "apple"){
            if(GameManager.Instance.pickApple.ToString() == "None"){
                GameManager.Instance.currentBinding = "pickApple";
                //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                menuPanel.ToggleMenu();
                //instantiate apples from this tree
            }
        } else if(fruitType == "coconut"){
            Debug.Log("FruitType is coconut");
            if(GameManager.Instance.pickCoconut.ToString() == "None"){
                GameManager.Instance.currentBinding = "pickCoconut";
                Debug.Log(GameManager.Instance.currentBinding);
                //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                menuPanel.ToggleMenu();
                //instantiate coconuts from this tree
            }
        } else if(fruitType == "orange"){
            if(GameManager.Instance.pickOrange.ToString() == "None"){
                GameManager.Instance.currentBinding = "pickOrange";
                //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                menuPanel.ToggleMenu();
                //instantiate oranges from this tree
            } 
        }
        
    }

    public void spawnFruit(){
        spawnPos = GameObject.Find("Player").transform.position + Vector3.forward;
        Instantiate(spawnee, spawnPos, Quaternion.identity);
    }

    // void OnTriggerStay(Collider other){
        // Debug.Log("Object is in the trigger");
    // }
    void OnTriggerExit(Collider other){
        Debug.Log("Object exited the trigger");
        if(canSpawn){
            Debug.Log("spawning");
            spawnFruit();
            canSpawn = false;
        }
        
    }
}
