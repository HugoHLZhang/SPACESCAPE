using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;
    private UIManager ui;
    [SerializeField] private float nextBreath = 5f;
    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        { 
            LoseOxygen(100);
        }
    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
        ui = GetComponent<UIManager>();
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
        ui.SetActiveHud(false);
    }
}
