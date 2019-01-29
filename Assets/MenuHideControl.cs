using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHideControl : MonoBehaviour
{

    public CanvasGroup CG;
    public bool IsMenuHidden;

    // Start is called before the first frame update
    void Start()
    {
        CG = GetComponent<CanvasGroup>();
    }

    public void HideMenu()
    {
        CG.alpha = 0f;
        CG.blocksRaycasts = false;
        CG.interactable = false;
    }

    public void ShowMenu() {
        CG.alpha = 1f;
        CG.blocksRaycasts = true;
        CG.interactable = true;
    }

    public void ToggleMenu() {
        if (IsMenuHidden) {
            ShowMenu();
            IsMenuHidden = false;
        }      
        else {
            HideMenu();
            IsMenuHidden = true;
        }  
    }

}
