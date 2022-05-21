using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : CharacterStats
{
    [SerializeField] public int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] private bool canAttack;
    public HealthBar healthBar;
    

    Vector3 RememberMeLocation;
    //private bool hasDroppedLoot = false;

    private void Start()
    {
        InitVariables();
        healthBar.setMaxHealth(maxHealth);
        
    }

    private void Update()
    {
        healthBar.setHealth(this.health);
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        base.GetComponentInChildren<Animator>().SetBool("isDying", true);
        RememberMeLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Destroy(gameObject, 5f);
        
    }
    

    public override void InitVariables()
    {
        base.InitVariables();
        maxHealth = 400;
        SetHealthTo(maxHealth);
        isDead = false;
        
        damage = 10;
        attackSpeed = 2.6f;
        canAttack = true;
    }
}
