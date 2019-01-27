using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicMenuScript : MonoBehaviour
{
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    GameObject label;

    bool waitingForKey;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = transform.Find("inputpromptBackground");
        menuPanel.gameObject.SetActive(false);
        waitingForKey = false;

        //setting up for initial movement
//        if(GameManager.Instance.forward.ToString() == "None") {
            
////            label = transform.Find("VerbLabel");
////            label.GetComponent<Text>().text = "Move";

        //    GameManager.Instance.currentBinding = "forward";
        //    menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
        //} else if (GameManager.Instance.backward.ToString() == "None"){
        //    GameManager.Instance.currentBinding = "backward";
        //    menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
        //} else if (GameManager.Instance.left.ToString() == "None"){
        //    GameManager.Instance.currentBinding = "left";
        //    menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
        //} else if (GameManager.Instance.right.ToString() == "None"){
        //    GameManager.Instance.currentBinding = "right";
        //    menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
        //}

        // loopPanelNames();

    }

    // Update is called once per frame
    void Update()
    {
        //for testing purposes comment out later
        if(Input.GetKeyDown(KeyCode.Escape)){
            menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
        }
    }

    void OnGUI(){
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey){
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName){
        keyName = GameManager.Instance.currentBinding;
        //where to set the currentBinding I think
        if(!waitingForKey){
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void sendText(Text text){
        buttonText = text;
    }

    IEnumerator WaitForKey(){
        while(!keyEvent.isKey) {
            yield return null;
        }
    }

    public IEnumerator AssignKey (string keyName){
        waitingForKey = true;
        yield return WaitForKey();
        switch(keyName){
            case "forward":
                GameManager.Instance.forward = newKey;
                PlayerPrefs.SetString("forwardKey", GameManager.Instance.forward.ToString());
                resetCurrentBinding();
                break;
            case "backward":
                GameManager.Instance.backward = newKey;
                PlayerPrefs.SetString("backwardKey", GameManager.Instance.backward.ToString());
                resetCurrentBinding();
                break;
            case "left":
                GameManager.Instance.left = newKey;
                PlayerPrefs.SetString("leftKey", GameManager.Instance.left.ToString());
                resetCurrentBinding();
                break;
            case "right":
                GameManager.Instance.right = newKey;
                PlayerPrefs.SetString("rightKey", GameManager.Instance.right.ToString());
                resetCurrentBinding();
                break;
            case "pickApple":
                GameManager.Instance.pickApple = newKey;
                PlayerPrefs.SetString("pickApple", GameManager.Instance.pickApple.ToString());
                resetCurrentBinding();
                break;
            case "pickCoconut":
                GameManager.Instance.pickCoconut = newKey;
                PlayerPrefs.SetString("pickCoconut", GameManager.Instance.pickCoconut.ToString());
                resetCurrentBinding();
                break;
            case "pickOrange":
                GameManager.Instance.pickOrange = newKey;
                PlayerPrefs.SetString("pickOrange", GameManager.Instance.pickOrange.ToString());
                resetCurrentBinding();
                break;
            case "feedCow":
                GameManager.Instance.feedCow = newKey;
                PlayerPrefs.SetString("feedCow", GameManager.Instance.feedCow.ToString());
                resetCurrentBinding();
                break;
            case "feedSheep":
                GameManager.Instance.feedSheep = newKey;
                PlayerPrefs.SetString("feedSheep", GameManager.Instance.feedSheep.ToString());
                resetCurrentBinding();
                break;
            case "feedPig":
                GameManager.Instance.feedPig = newKey;
                PlayerPrefs.SetString("feedPig", GameManager.Instance.feedPig.ToString());
                resetCurrentBinding();
                break;
        }
        yield return null;
    }

    public void resetCurrentBinding(){
        GameManager.Instance.currentBinding = "";
        menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
    }

    public void resetBindings(){
        //movement
        GameManager.Instance.forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "W");
        GameManager.Instance.backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "S");
        GameManager.Instance.left = (KeyCode) System.Enum.Parse(typeof(KeyCode), "A");
        GameManager.Instance.right = (KeyCode) System.Enum.Parse(typeof(KeyCode), "D");
        //pick ups
        GameManager.Instance.pickApple = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.pickOrange = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.pickCoconut = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        //setting feeding
        GameManager.Instance.feedCow = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.feedSheep = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.feedPig = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        
        PlayerPrefs.SetString("forwardKey", GameManager.Instance.forward.ToString());
        PlayerPrefs.SetString("backwardKey", GameManager.Instance.backward.ToString());
        PlayerPrefs.SetString("leftKey", GameManager.Instance.left.ToString());
        PlayerPrefs.SetString("rightKey", GameManager.Instance.right.ToString());
        
        PlayerPrefs.SetString("pickApple", GameManager.Instance.pickApple.ToString());
        PlayerPrefs.SetString("pickOrange", GameManager.Instance.pickOrange.ToString());
        PlayerPrefs.SetString("pickCoconut", GameManager.Instance.pickCoconut.ToString());
        
        PlayerPrefs.SetString("feedCow", GameManager.Instance.feedCow.ToString());
        PlayerPrefs.SetString("feedSheep", GameManager.Instance.feedSheep.ToString());
        PlayerPrefs.SetString("feedPig", GameManager.Instance.feedPig.ToString());
        // loopPanelNames();
    }

    //updates text of Buttons
    //should be redundant
    public void loopPanelNames(){
        for(int i = 0; i < menuPanel.childCount; i++){
            if(menuPanel.GetChild(i).name == "ForwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.forward.ToString();
            else if(menuPanel.GetChild(i).name == "BackwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.backward.ToString();
            else if(menuPanel.GetChild(i).name == "LeftKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.left.ToString();
            else if(menuPanel.GetChild(i).name == "RightKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.right.ToString();
            else if(menuPanel.GetChild(i).name == "PickApple")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.pickApple.ToString();
        }
    }

}

