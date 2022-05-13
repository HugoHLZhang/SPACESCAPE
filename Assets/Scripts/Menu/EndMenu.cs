using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);//main
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);//menu
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
