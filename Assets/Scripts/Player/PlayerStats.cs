using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : CharacterStats
{
    #region
    public static PlayerStats playerStats;

    private void Awake()
    {
        playerStats = this.GetComponent<PlayerStats>();
    }
    #endregion

    [SerializeField] protected int poison;
    [SerializeField] protected int maxPoison;

    private PlayerHUD hud;
    [SerializeField] private float nextBreath = 600f;
    [SerializeField] private float poisonTimer = 300f;

    private bool isHealedfromPoison;

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
            
            yield return new WaitForSeconds(2f);
            nextBreath-=2f;
            LoseOxygen(1);
        }
    }

    public IEnumerator increasePoisonTimer()
    {
        while (poisonTimer > 0 && !isHealedfromPoison)
        {
            yield return new WaitForSeconds(2f);
            poisonTimer+=1f;
            increasePoison(1);
            if (poison == 75)
            {
                FindObjectOfType<AudioManager>().Play("Poison75");
            }
        }
    }

    public void CheckPoison()
    {
        Debug.Log(poison);
        if (poison >= 100)
        {
            health = 0;
            oxygen = 0;
            Die();
        }
        if (poison < maxPoison)
        {
            isDead = false;
        }
        hud.UpdatePoison(poison, maxPoison);
    }

    public void SetPoisonTo(int poisonToSetTo)
    {
        poison = poisonToSetTo;
        CheckPoison();
    }

    public void increasePoison(int amount)
    {
        CheckPoison();
        int poisonAfterAddition = poison + amount;
        if(poisonAfterAddition > 100)
        {
            poisonAfterAddition = 100;
        }

        SetPoisonTo(poisonAfterAddition);
    }

    public void healFromPoison(int antidote)
    {
        int poisonAfterHeal = poison - antidote;
        SetPoisonTo(poisonAfterHeal);
        isHealedfromPoison = true;
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        RenderSettings.skybox.SetFloat("Rotation", (Time.timeSinceLevelLoad) * 0.2f);

        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("DeathSound");
        FindObjectOfType<AudioManager>().Stop("BreathingPlayer");
        FindObjectOfType<AudioManager>().Stop("PoisonSound");
        FindObjectOfType<AudioManager>().Play("DeathScreen");
        FindObjectOfType<AudioManager>().Stop("Poison75");

    }

    public override void InitVariables()
    {
        base.InitVariables();
        SetPoisonTo(0);
        maxPoison = 100;
    }

}
