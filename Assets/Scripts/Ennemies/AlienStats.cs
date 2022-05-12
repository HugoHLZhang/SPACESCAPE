using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : CharacterStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;

    [SerializeField] private bool canAttack;

    private void Start()
    {
        InitVariables();
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public override void InitVariables()
    {
        base.InitVariables();
        maxHealth = 25;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 2.6f;
        canAttack = true;
    }
}
