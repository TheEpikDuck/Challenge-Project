//pause menu and the button functions when pressed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource background;
    public AudioSource audioSource;


    public void Pause()
    {
        audioSource.Play();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        background.Pause();
    }

    public void Menu()
    {
        audioSource.Play();
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        audioSource.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        background.Play();
    }

    public void Restart()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
