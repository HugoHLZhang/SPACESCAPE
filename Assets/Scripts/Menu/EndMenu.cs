using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);//main
        FindObjectOfType<AudioManager>().Stop("DeathScreen");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);//menu
        FindObjectOfType<AudioManager>().Stop("DeathScreen");
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
