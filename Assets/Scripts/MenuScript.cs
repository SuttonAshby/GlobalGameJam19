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
        menuPanel.gameObject.SetActive(false);
        waitingForKey = false;

        for(int i = 0; i < menuPanel.childCount; i++){
            if(menuPanel.GetChild(i).name == "ForwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.forward.ToString();
            else if(menuPanel.GetChild(i).name == "BackwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.backward.ToString();
            else if(menuPanel.GetChild(i).name == "LeftKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.left.ToString();
            else if(menuPanel.GetChild(i).name == "RightKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.Instance.right.ToString();
        }
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
                break;
            case "backward":
                GameManager.Instance.backward = newKey;
                buttonText.text = GameManager.Instance.backward.ToString();
                break;
            case "left":
                GameManager.Instance.left = newKey;
                buttonText.text = GameManager.Instance.left.ToString();
                break;
            case "right":
                GameManager.Instance.right = newKey;
                buttonText.text = GameManager.Instance.right.ToString();
                break;
        }
        yield return null;
    }

}
