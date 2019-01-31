using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public MenuControl menuPanel;
    public string fruitType;
    public GameObject spawnee;
    public Vector3 spawnPos;
    private bool canSpawn;
    private float targetTime = 30f;
    private float timer;

    void Start()
    {
        menuPanel = GameObject.Find("inputpromptBackground").GetComponent<MenuControl>();
        timer = 0;
        canSpawn = true;
    }

    void Update(){
        if(!canSpawn){
           targetTime -= Time.deltaTime;
           if(targetTime <= 0.0f){
               targetTime = 0.0f;
               canSpawn = true;
           } 
        }

    }


    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")) {
            Debug.Log("Player has entered the trigger");
            if(fruitType == "apple"){
                if(GameManager.Instance.pickApple.ToString() == "None"){
                    GameManager.Instance.currentBinding = "pickApple";
                    //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                    menuPanel.UpdateMenu("pickApple");
                    menuPanel.ToggleMenu();
                    //instantiate apples from this tree
                }
            } else if(fruitType == "coconut"){
                Debug.Log("FruitType is coconut");
                if(GameManager.Instance.pickCoconut.ToString() == "None"){
                    GameManager.Instance.currentBinding = "pickCoconut";
                    Debug.Log(GameManager.Instance.currentBinding);
                    //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                    menuPanel.UpdateMenu("pickCoconut");
                    menuPanel.ToggleMenu();
                    //instantiate coconuts from this tree
                }
            } else if(fruitType == "orange"){
                if(GameManager.Instance.pickOrange.ToString() == "None"){
                    GameManager.Instance.currentBinding = "pickOrange";
                    //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                    menuPanel.UpdateMenu("pickOrange");
                    menuPanel.ToggleMenu();
                    //instantiate oranges from this tree
                } 
            }

            if (canSpawn)
            {
                canSpawn = false;
                Debug.Log("spawning");
                spawnFruit();
                timer = targetTime;
            }
        }
    }

    public void spawnFruit(){
        spawnPos = ((GameObject.Find("Player").transform.position + transform.position) / 2) + (Vector3.up * 2.8f);
        Instantiate(spawnee, spawnPos, Quaternion.identity);
        GetComponent<ObjectSounds>().PlayRandomSound();
    }

    // void OnTriggerStay(Collider other){
        // Debug.Log("Object is in the trigger");
    // }
    void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")) {
            Debug.Log("Player exited the trigger");
        }
    }
}
