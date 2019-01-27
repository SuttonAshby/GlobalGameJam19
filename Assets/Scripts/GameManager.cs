﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager Instance {get; private set; }

    //total lives
    public int lives = 100;

    //movment bindings
    public KeyCode forward {get; set;}
    public KeyCode backward {get; set;}
    public KeyCode left {get; set;}
    public KeyCode right {get; set;}
    // pick up bindings
    public KeyCode pickApple {get; set;}
    public KeyCode pickCoconut {get; set;}
    public KeyCode pickOrange {get; set;}
    // feed bindings
    public KeyCode feedCow {get; set;}
    public KeyCode feedSheep {get; set;}
    public KeyCode feedPig {get; set;}

    //animal fruit anti-pairing
    public string cowNotEat = "apple";
    public string sheepNotEat = "orange";
    public string pigNotEat = "coconut";
    
    //animal proximity
    public bool nearCow = false;
    public bool nearSheep = false;
    public bool nearPig = false;

    //keep track of what is being bound now
    public string currentBinding = "";

  	private void Awake () {
        //initiate singleton
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

    //setting bindings to player preferences or default
    //setting movement
    forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
    backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
    left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
    right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
    //setting pick ups
    // pickApple = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pickApple", "E"));
    pickApple = (KeyCode) System.Enum.Parse(typeof(KeyCode), "E"); //TESTING PURPOSES
	pickOrange = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pickOrange", "None"));
    // pickCoconut = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pickCoconut", "None"));
    pickCoconut = (KeyCode) System.Enum.Parse(typeof(KeyCode), "T"); //TESTING PURPOSES
    //setting feeding
    // feedCow = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("feedCow", "None"));
    feedCow = (KeyCode) System.Enum.Parse(typeof(KeyCode), "R"); //TESTING PURPOSES
    feedSheep = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("feedSheep", "None"));
    feedPig = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("feedPig", "None"));
    }


  

}
