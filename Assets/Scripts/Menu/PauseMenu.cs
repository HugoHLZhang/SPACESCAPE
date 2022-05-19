using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //et différent de mort
        {
            if (GameIsPaused)
            {
                Resume();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                FindObjectOfType<AudioManager>().Play("Theme");
                FindObjectOfType<AudioManager>().Stop("PauseTheme");
                FindObjectOfType<AudioManager>().Play("PauseHit");

            }
            else//pause on key escape
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                FindObjectOfType<AudioManager>().Play("PauseHit");
                FindObjectOfType<AudioManager>().Pause("Theme");
                FindObjectOfType<AudioManager>().Play("PauseTheme");
            }
        }

        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; //time is back to normal 
        GameIsPaused = false;
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().Stop("PauseTheme");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //freeze the game by freezing the time //methode can be used for slowmotion
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); //change scene
        RenderSettings.skybox.SetFloat("Rotation", (Time.timeSinceLevelLoad) * 0.2f);
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Stop("PauseTheme");
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
