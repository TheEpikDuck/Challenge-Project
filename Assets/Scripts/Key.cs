//code for the one key to unlock the portal during the minigame in world 1-2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Portal")
        {    
            SceneManager.LoadScene(5);
        }
    }
}
