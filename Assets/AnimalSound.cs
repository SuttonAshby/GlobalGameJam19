using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    public float Threshhold = 0.1f;
    public float RandomTiming = 0.0f;

    private float counter = 0;
    private ObjectSounds objectSounds;
    private bool willPlay;

    
    void Start()
    {
        objectSounds = GetComponent<ObjectSounds>();
    }

    
    void Update()
    {
        if ((gameObject.name == "cow") && (GameManager.Instance.nearCow == true))
            {
            willPlay = true;
        }
        if ((gameObject.name == "pig") && (GameManager.Instance.nearPig == true))
         {
            willPlay = true;
         }
        if ((gameObject.name == "sheep") && (GameManager.Instance.nearSheep == true))
         {
            willPlay = true;
        }
        if (willPlay == true)
        {
            counter += Time.deltaTime;
            if (counter >= Random.Range(Threshhold, Threshhold + RandomTiming))
            {
                counter = 0;
                if (objectSounds.Clips != null)
                {
                    objectSounds.PlayRandomSound();
                }
            }
        }


    }
}
