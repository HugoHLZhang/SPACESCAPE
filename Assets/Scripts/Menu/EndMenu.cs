using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public static bool GameIsEnd = false;
    public GameObject endMenuUI;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (GameIsEnd)
            {
                Restart();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.Confined;
            }
        }


    }
    //button R
    public void Restart()
    {

        endMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; //time is back to normal 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameIsEnd = false;
    }

    void Pause()
    {
        endMenuUI.SetActive(true);
        Time.timeScale = 0f; //freeze the game by freezing the time //methode can be used for slowmotion
        GameIsEnd = true;
    }



    //button Menu
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //change scene
        RenderSettings.skybox.SetFloat("Rotation", (Time.timeSinceLevelLoad) * 0.2f);
    }
    //button Quit
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
