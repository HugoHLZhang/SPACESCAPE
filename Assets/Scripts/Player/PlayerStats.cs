using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
            
        //if (isDead == true)
        //{
        //    InitVariables();
        //    CheckHealth();
        //    CheckOxygen();
        //    Debug.Log(isDead);
        //}
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

}
