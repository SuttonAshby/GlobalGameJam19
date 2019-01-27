 using UnityEngine;
 using System.Collections;
 
 public class SimpleTimer: MonoBehaviour {
 
 public float targetTime = 60.0f;
 
 void Update(){
 
 targetTime -= Time.deltaTime;
 
 if (targetTime <= 0.0f)
 {
    timerEnded();
 }
 
 }
 
 void timerEnded()
 {
    //decrement a life and reload the scene
 }
 
 
 }
