using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectController : MonoBehaviour
{
    public string objectName;
    public bool canBeInteracted = false;

    private Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


}
