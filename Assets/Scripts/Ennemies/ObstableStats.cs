using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstableStats : CharacterStats
{
    [SerializeField] private int obstacleHealth;
    private void Start()
    {
        InitVariables();
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
    public override void InitVariables()
    {
        base.InitVariables();
        maxHealth = obstacleHealth;
        SetHealthTo(maxHealth);
        isDead = false;
    }
}
