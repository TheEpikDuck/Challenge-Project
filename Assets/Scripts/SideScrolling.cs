//this is used to follow the charcter 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform mario;

    private void Start ()
    {
        mario = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position; 
        cameraPosition.x = Mathf.Max(cameraPosition.x, mario.position.x);
        transform.position = cameraPosition;
    }

    
}
