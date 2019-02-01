using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Vector2 rotation = new Vector2 (0,0);
    // public float speed = 3f;

    public float lookSpeed = 3f;
    private Vector2 rotation = Vector2.zero;

    public void Start() {
        Camera.main.transform.localRotation = Quaternion.Euler(120f, 0, 0);
    }

    public void Update() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0,rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     rotation.y += Input.GetAxis ("Mouse X");
    //     // rotation.x += Input.GetAxis ("Mouse X");
    //     // rotation.y = Mathf.Clamp (rotation.y, -60f, 60f);
    //     transform.eulerAngles = (Vector2)rotation * speed;        
    // }
}
