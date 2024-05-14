//button when clicked on world 1-1 in the level selector screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource background;

    public void Start()
    {
        background.Play();
    }

    public void OnBackButton()
    {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }

    public void OnButton()
    {
        audioSource.Play();
        SceneManager.LoadScene(2);
    }
}
