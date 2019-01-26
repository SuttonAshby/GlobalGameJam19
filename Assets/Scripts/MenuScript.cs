using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = transform.Find("Panel");

        //setting up for initial movement
        if(GameManager.Instance.forward.ToString() != "None") {
            menuPanel.gameObject.SetActive(false);
        }
        waitingForKey = false;

        loopPanelNames();

    }

    // Update is called once per frame
    void Update()
    {
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
                buttonText.text = GameManager.Instance.forward.ToString();
                PlayerPrefs.SetString("forwardKey", GameManager.Instance.forward.ToString());
                break;
            case "backward":
                GameManager.Instance.backward = newKey;
                buttonText.text = GameManager.Instance.backward.ToString();
                PlayerPrefs.SetString("backwardKey", GameManager.Instance.backward.ToString());
                break;
            case "left":
                GameManager.Instance.left = newKey;
                buttonText.text = GameManager.Instance.left.ToString();
                PlayerPrefs.SetString("leftKey", GameManager.Instance.left.ToString());
                break;
            case "right":
                GameManager.Instance.right = newKey;
                buttonText.text = GameManager.Instance.right.ToString();
                PlayerPrefs.SetString("rightKey", GameManager.Instance.right.ToString());
                break;
            case "pickApple":
                GameManager.Instance.pickApple = newKey;
                buttonText.text = GameManager.Instance.pickApple.ToString();
                PlayerPrefs.SetString("pickApple", GameManager.Instance.pickApple.ToString());
                break;
        }
        yield return null;
    }

    public void resetBindings(){
        GameManager.Instance.forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.left = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.right = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        GameManager.Instance.pickApple = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        PlayerPrefs.SetString("forwardKey", GameManager.Instance.forward.ToString());
        PlayerPrefs.SetString("backwardKey", GameManager.Instance.backward.ToString());
        PlayerPrefs.SetString("leftKey", GameManager.Instance.left.ToString());
        PlayerPrefs.SetString("rightKey", GameManager.Instance.right.ToString());
        PlayerPrefs.SetString("pickApple", GameManager.Instance.right.ToString());
        loopPanelNames();
    }

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
