using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Stop("PauseTheme");
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
        FindObjectOfType<AudioManager>().Stop("BreathingPlayer");
        FindObjectOfType<AudioManager>().Stop("PoisonSound");
        FindObjectOfType<AudioManager>().Stop("Poison75");
        FindObjectOfType<AudioManager>().Stop("PowerDown");
        FindObjectOfType<AudioManager>().Stop("SwapToSaber");
        FindObjectOfType<AudioManager>().Stop("EquipSaber");
        FindObjectOfType<AudioManager>().Stop("DoorSound");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

}
