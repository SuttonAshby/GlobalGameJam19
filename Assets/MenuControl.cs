using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MenuControl : MonoBehaviour
{

    // Control Visibility
    public CanvasGroup CG;
    public bool IsMenuHidden;

    //Configure Display
    public TextMeshProUGUI VerbDisplay;

    string VerbPick = "Pick";
    string VerbFeed = "Feed";

    public Image AppleIcon;
    public Image OrangeIcon;
    public Image CoconutIcon;
    public Image BootIcom;

    public Image CowIcon;
    public Image SheepIcon;
    public Image PigIcon;
    public Image DinoIcon;

    // Start is called before the first frame update
    void Start()
    {
        CG = GetComponent<CanvasGroup>();
    }


    //Menu Visibility
    public void InitializeMenu() {
        IsMenuHidden = true;
        CG.DOFade(0f, 0f);
        CG.blocksRaycasts = false;
        CG.interactable = false;
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

    //Menu COntent Display

    public void UpdateMenu(string keyAction) {
        switch (keyAction) {
            case "pickApple":
                VerbDisplay.text = VerbPick;
                ResetIcons();
                AppleIcon.color = Color.white;
                break;
            case "pickOrange":
                VerbDisplay.text = VerbPick;
                ResetIcons();
                OrangeIcon.color = Color.white;
                break;
            case "pickCoconut":
                VerbDisplay.text = VerbPick;
                ResetIcons();
                CoconutIcon.color = Color.white;
                break;
            case "feedSheep":
                VerbDisplay.text = VerbFeed;
                ResetIcons();
                SheepIcon.color = Color.white;
                break;
            case "feedCow":
                VerbDisplay.text = VerbFeed;
                ResetIcons();
                CowIcon.color = Color.white;
                break;
            case "feedPig":
                VerbDisplay.text = VerbFeed;
                ResetIcons();
                PigIcon.color = Color.white;
                break;
        }
    }

    void ResetIcons() {
        AppleIcon.color = Color.clear;
        OrangeIcon.color = Color.clear;
        CoconutIcon.color = Color.clear;
        BootIcom.color = Color.clear;

        CowIcon.color = Color.clear;
        SheepIcon.color = Color.clear;
        PigIcon.color = Color.clear;
        DinoIcon.color = Color.clear;
    }
}
