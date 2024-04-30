//used to detect wether the charcter is interacting with an interactable object
//used a tutorial for this

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Parameters")]
    //Detection Point
    public Transform detectionPoint;
    //Detection Radius
    private const float detectionRadius = 0.2f;
    //Detection Layer
    public LayerMask detectionLayer;
    //Detected object
    public GameObject detectedObject;
    [Header("Others")]

    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;
    //;ist of picked items
    public List<GameObject>pickedItems = new List<GameObject>();

    public bool isGrabbing;

    
    void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
                if(isGrabbing)
                {
                    GrabDrop();
                    return;
                }   
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
        if(obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }

    }

    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
    }

    public void GrabDrop()
    {
        if(isGrabbing)
        {
            isGrabbing = false;
            grabbedObject.transform.parent = null;
            grabbedObject.transform.position = new Vector3(grabbedObject.transform.position.x,grabbedObjectYValue,grabbedObject.transform.position.z);
            grabbedObject = null;
        }

        else
        {
            isGrabbing = true;
            grabbedObject = detectedObject;
            grabbedObject.transform.parent = transform;
            grabbedObjectYValue = grabbedObject.transform.position.y;
            grabbedObject.transform.localPosition = grabPoint.localPosition;
        }
    }

}
