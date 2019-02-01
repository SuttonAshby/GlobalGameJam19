using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //total lives and time
    public int lives = 40;
    public float startTimeLeft = 123f;
    public int score = 0;
    public float timeLeft;
    public List<KeyCode> boundKeyCodes = new List <KeyCode> ();

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

        //Initialize timer
        timeLeft = startTimeLeft;

    //setting bindings to player preferences or default
    //setting movement
    forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
    backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
    left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
    right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
    //setting pick ups
    pickApple = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pickApple", "None"));
    // pickApple = (KeyCode) System.Enum.Parse(typeof(KeyCode), "E"); //TESTING PURPOSES
        pickOrange = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pickOrange", "None"));
        pickCoconut = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pickCoconut", "None"));
    // pickCoconut = (KeyCode) System.Enum.Parse(typeof(KeyCode), "T"); //TESTING PURPOSES
    //setting feeding
        feedCow = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("feedCow", "None"));
    // feedCow = (KeyCode) System.Enum.Parse(typeof(KeyCode), "R"); //TESTING PURPOSES
        feedSheep = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("feedSheep", "None"));
        feedPig = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("feedPig", "None"));
    }

    // Update is called once per frame
    //the timer and either soft or hard resets
    void Update(){
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0){
            if(lives > 1){
                lives -= 1;
                timeLeft = startTimeLeft;
                SceneManager.LoadScene("Blockmesh"); 
            } else {
                lives = 101;
                //hard reset
                resetBindings();
                SceneManager.LoadScene("Blockmesh");
            }
        }    
    }

    public void resetBindings(){
        //movement
        resetForward();
        resetBackward();
        resetLeft();
        resetRight();
        //pick ups
        resetPickApple();
        resetPickOrange();
        resetPickCoconut();
        //setting feeding
        resetFeedCow();
        resetFeedSheep();
        resetFeedPig();
        //resets the list of already bound keycodes
        boundKeyCodes.Clear();
    }

    public void scoreUp () {
        score++;
        Debug.Log("Score goes up! Score: " + score);
    }

    public void scoreReset () {
        score = 0;
    }

    public void resetForward(){
        forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "W");
        PlayerPrefs.SetString("forwardKey", forward.ToString());
    }
    public void resetBackward(){
        backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "S");
        PlayerPrefs.SetString("backwardKey", backward.ToString());
    }
    public void resetLeft(){
        left = (KeyCode) System.Enum.Parse(typeof(KeyCode), "A");
        PlayerPrefs.SetString("leftKey", left.ToString());
    }
    public void resetRight(){
        right = (KeyCode) System.Enum.Parse(typeof(KeyCode), "D");
        PlayerPrefs.SetString("rightKey", right.ToString());
    }
    public void resetPickApple(){
        pickApple = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        PlayerPrefs.SetString("pickApple", pickApple.ToString());
    }
    public void resetPickOrange(){
        pickOrange = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        PlayerPrefs.SetString("pickOrange", pickOrange.ToString());
    }
    public void resetPickCoconut(){
        pickCoconut = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        PlayerPrefs.SetString("pickCoconut", pickCoconut.ToString());
    }
    public void resetFeedCow(){
        feedCow = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        PlayerPrefs.SetString("feedCow", feedCow.ToString());
    }
    public void resetFeedSheep(){
        feedSheep = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        PlayerPrefs.SetString("feedSheep", feedSheep.ToString());
    }
    public void resetFeedPig(){
        feedPig = (KeyCode) System.Enum.Parse(typeof(KeyCode), "None");
        PlayerPrefs.SetString("feedPig", feedPig.ToString());
    }
}
