using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : CharacterStats
{
    [SerializeField] public int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] public GameObject loot;
    [SerializeField] private bool canAttack;

    
    Vector3 RememberMeLocation;
    private bool hasDroppedLoot = false;

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
        base.GetComponentInChildren<Animator>().SetBool("isDying",true);
        RememberMeLocation =new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Destroy(gameObject,3f);
        if (hasDroppedLoot == false && Random.value > 0.5f)
        {
            Instantiate(loot, RememberMeLocation, gameObject.transform.rotation);
            hasDroppedLoot = true;        
        }
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
