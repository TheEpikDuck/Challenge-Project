//this is to trigger the win menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winMenu;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(Finish());
        }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(2); 
        winMenu.gameObject.SetActive(true);
    } 

    }
}
 