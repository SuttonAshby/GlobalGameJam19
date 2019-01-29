using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        CG.DOFade(0f, 0.25f);
        CG.blocksRaycasts = false;
        CG.interactable = false;
    }

    public void ShowMenu() {
        CG.DOFade(1f, 0.25f);
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
