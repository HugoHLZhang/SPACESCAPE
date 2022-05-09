using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;
    [SerializeField] private float nextBreath = 5f;
    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void Update()
    {
        if(nextBreath < Time.time)
        { 
            LoseOxygen(1);
            nextBreath += 5f;
        }
        //if (isDead == true)
        //{
        //    InitVariables();
        //    CheckHealth();
        //    CheckOxygen();
        //    Debug.Log(isDead);
        //}
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
