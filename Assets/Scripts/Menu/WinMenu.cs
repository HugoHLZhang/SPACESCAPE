using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
        FindObjectOfType<AudioManager>().Stop("TakeOff");
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Stop("TakeOff");
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
