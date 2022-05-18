using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;
    [SerializeField] private float nextBreath = 600f;
    private void Start()
    {
        GetReferences();
        InitVariables();
        StartCoroutine(timer());
    }

    private void Update()
    {
        
    }

    IEnumerator timer()
    {
        while (nextBreath > 0)
        {
            nextBreath--;
            yield return new WaitForSeconds(5f);
            LoseOxygen(1);
        }
    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(health, maxHealth); 
    }

    public override void CheckOxygen()
    {
        base.CheckOxygen();
        hud.UpdateOxygen(oxygen, maxOxygen);
    }

    public void Breathe()
    {
        LoseOxygen(1);
    }

    public override void Die()
    {
        base.Die();
        Time.timeScale = 1f;
        SceneManager.LoadScene(2); //change scene
        Cursor.lockState = CursorLockMode.Confined;
        RenderSettings.skybox.SetFloat("Rotation", (Time.timeSinceLevelLoad) * 0.2f);

        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("DeathSound");
        FindObjectOfType<AudioManager>().Stop("BreathingPlayer");

    }

}
