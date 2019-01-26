using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager Instance {get; private set; }

    public KeyCode forward {get; set;}
    public KeyCode backward {get; set;}
    public KeyCode left {get; set;}
    public KeyCode right {get; set;}

    

  	private void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

    forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "W");
    backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), "S");
    left = (KeyCode) System.Enum.Parse(typeof(KeyCode), "A");
    right = (KeyCode) System.Enum.Parse(typeof(KeyCode), "D");

	}


  

}
