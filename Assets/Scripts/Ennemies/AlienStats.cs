using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : CharacterStats
{
    [SerializeField] public int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] public GameObject loot_O2;
    [SerializeField] public GameObject loot_MedKit;
    [SerializeField] public GameObject loot_MedKit_virus;
    [SerializeField] public GameObject loot_Timer;
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
        if (hasDroppedLoot == false && Random.value < 0.4f)
        {
            Instantiate(loot_O2, RememberMeLocation, gameObject.transform.rotation);
            hasDroppedLoot = true;        
        }
        if (hasDroppedLoot == false &&  0.4f < Random.value && Random.value < 0.55f )
        {
            Instantiate(loot_MedKit, RememberMeLocation + new Vector3(0,0.22f,0), loot_MedKit.transform.rotation);
            
            hasDroppedLoot = true;
        }
        if (hasDroppedLoot == false && Random.value > 0.8f)
        {
            Instantiate(loot_Timer, RememberMeLocation + new Vector3(0, 0.22f, 0), loot_Timer.transform.rotation);

            hasDroppedLoot = true;
        }
        if (hasDroppedLoot == false && 0.55f < Random.value && Random.value < 0.8f)
        {
            Instantiate(loot_MedKit_virus, RememberMeLocation + new Vector3(0, 0.22f, 0), loot_MedKit_virus.transform.rotation);

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
