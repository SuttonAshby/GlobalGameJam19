using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public Camera fpsCamera;
    public LayerMask interactiveLayer;
    public float maxInteractionDistance = 1f;
    private GameObject _interactiveObject = null;
    private GameObject _pickupObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, maxInteractionDistance, interactiveLayer.value))
        {
            Debug.Log(hit.transform.name);
            InteractiveObjectController interactiveObjectController = hit.collider.GetComponent<InteractiveObjectController>();
            if (interactiveObjectController)
            {
                Debug.Log("I see " + interactiveObjectController.objectName + ". object info: " + hit.collider.gameObject);
            }
        }
        _interactiveObject = null;
    }

    private void OnDrawGizmos()
    {
        Color cameraColor = Color.yellow;
        Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * maxInteractionDistance, cameraColor);
    }

}


