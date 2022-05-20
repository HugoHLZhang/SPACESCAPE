using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Die();
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
            isDead = false;
        }
    }

    public virtual void CheckOxygen()
    {
        if( oxygen <= 0)
        {
            oxygen = 0;
            health = 0;
            Die();
        }
        if (oxygen >= maxOxygen)
        {
            oxygen = maxOxygen;
            isDead = false;
        }
        if (oxygen <= 10)
        {
            FindObjectOfType<AudioManager>().Play("BreathingPlayer");
        }
    }

    public virtual void Die()
    {
        isDead = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Cursor.lockState = CursorLockMode.Confined;
    }

    public bool IsDead()
    {
        return isDead;
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
        CheckHealth();
        int healthAfterDamge = health - damage;
        SetHealthTo(healthAfterDamge);
        
        
    }

    public void LoseOxygen(int amount)
    {
        CheckHealth();
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

    public virtual void InitVariables()
    {
        maxOxygen = 100;
        maxHealth = 100;
        isDead = false;
        SetHealthTo(maxHealth);
        SetOxygenTo(maxOxygen);
        
    }
}
