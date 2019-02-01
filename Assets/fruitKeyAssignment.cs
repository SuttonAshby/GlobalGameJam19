using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitKeyAssignment : MonoBehaviour
{

    public MenuControl menuPanel;
    public string fruitType;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.Find("inputpromptBackground").GetComponent<MenuControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the fruit trigger");
            if (fruitType == "apple")
            {
                if (GameManager.Instance.pickApple.ToString() == "None")
                {
                    GameManager.Instance.currentBinding = "pickApple";
                    //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                    menuPanel.UpdateMenu("pickApple");
                    menuPanel.ToggleMenu();
                    //instantiate apples from this tree
                }
            }
            else if (fruitType == "coconut")
            {
                Debug.Log("FruitType is coconut");
                if (GameManager.Instance.pickCoconut.ToString() == "None")
                {
                    GameManager.Instance.currentBinding = "pickCoconut";
                    Debug.Log(GameManager.Instance.currentBinding);
                    //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                    menuPanel.UpdateMenu("pickCoconut");
                    menuPanel.ToggleMenu();
                    //instantiate coconuts from this tree
                }
            }
            else if (fruitType == "orange")
            {
                if (GameManager.Instance.pickOrange.ToString() == "None")
                {
                    GameManager.Instance.currentBinding = "pickOrange";
                    //menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
                    menuPanel.UpdateMenu("pickOrange");
                    menuPanel.ToggleMenu();
                    //instantiate oranges from this tree
                }
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the fruit trigger");
        }
    }
}
