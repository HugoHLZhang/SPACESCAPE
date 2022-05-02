using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected int oxygen;
    [SerializeField] protected int maxOxygen;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVariables();
    }



    public virtual void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            oxygen = 0;
            isDead = true;
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void CheckOxygen()
    {
        if( oxygen <= 0)
        {
            oxygen = 0;
            health = 0;
            isDead = true;
        }
        if (oxygen >= maxOxygen)
        {
            oxygen = maxOxygen;
        }
    }

    public void Die()
    {
        isDead = true;
    }

    public void SetOxygenTo(int oxygenToSetTo)
    {
        oxygen = oxygenToSetTo;
        CheckOxygen();
    }

    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamge = health - damage;
        SetHealthTo(healthAfterDamge);
    }

    public void LoseOxygen(int amount)
    {
        int oxygenAfterTime = oxygen - amount;
        SetOxygenTo(oxygenAfterTime);
    }

    public void Heal(int heal)
    {
        int healthAfterHeal = health + heal;
        SetHealthTo(healthAfterHeal);
    }

    public void takeOxygen(int air)
    {
        int oxygenAfterTakeOxygen = oxygen + air;
        SetOxygenTo(oxygenAfterTakeOxygen);
    }

    public void InitVariables()
    {
        maxOxygen = 100;
        maxHealth = 100;
        SetHealthTo(maxHealth);
        SetOxygenTo(maxOxygen);
        isDead = false;
    }
}
