//button for when clicked on world 1-2 during the level selector screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherMenu2 : MonoBehaviour
{
   

    public void Start()
    {
        
    }

    public void OnBackButton()
    {
        
        SceneManager.LoadScene(0);
    }

    public void OnButton()
    {
        
        SceneManager.LoadScene(3);
    }
}

