using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Transform target;
    private Animator anim = null;
    private Animator SaberAnim = null;
    private float attackTimer;
    private bool hasStopped = false;
    private Vector3 playerPosition;
    [SerializeField] private GameObject meleeWeapons;
    [SerializeField] private GameObject rangeWeapons;
    [SerializeField] public Transform ItemHolder = null;
    public GameObject currentItemObject = null;
    public int CountAttack;
    public bool MeleePattern;
    public bool isSwitching;
    private string triggerAnim;
    private BossStats stats = null;
    private float speedCap;
    private void Start()
    {
        
        GetReference();
        Instantiate(meleeWeapons, ItemHolder);
        
    }   
    private void Update()
    {
        moveToTarget();
        
        
    }


    private void moveToTarget()
    {
        agent.SetDestination(target.position);
        patternManager();

        float distanceBetweenPlayer = Vector3.Distance(target.position, transform.position) - 0.3f;
        if (MeleePattern)
        {
            agent.speed = 7;
            if (distanceBetweenPlayer <= agent.stoppingDistance)
            {
                stats.attackSpeed = 2.6f;
                anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
                RotateToTarget();
                //Attack
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (!hasStopped)
                {
                    hasStopped = true;
                    attackTimer = Time.time;
                    StartCoroutine(AttackTarget(targetStats));
                }

                if (Time.time >= attackTimer + stats.attackSpeed)
                {
                    attackTimer = Time.time;
                    StartCoroutine(AttackTarget(targetStats));

                }
                //gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            }
        }
        if (!MeleePattern)
        {
            agent.speed = 0;
            stats.attackSpeed = 1f;
            if (distanceBetweenPlayer <= agent.stoppingDistance + 300)
            {
                
                anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
                RotateToTarget();
                //Attack
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (!hasStopped)
                {
                    hasStopped = true;
                    attackTimer = Time.time;
                    StartCoroutine(AttackTarget(targetStats));
                }

                if (Time.time >= attackTimer + stats.attackSpeed)
                {
                    attackTimer = Time.time;
                    StartCoroutine(AttackTarget(targetStats));

                }
                //gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            }
        }

        if (anim.GetBool("isDying") == true)
        {
            agent.speed = 0;
            agent.angularSpeed = 0;
            agent.stoppingDistance = 0;
            stats.damage = 0;
        }
        else
        {
            anim.SetFloat("Speed", 1f, 0.5f, Time.deltaTime);
            if (hasStopped)
            {
                hasStopped = true;
            }
        }

    }

    private IEnumerator AttackTarget(CharacterStats statsToDamage)
    {
        if(MeleePattern)
        {
            anim.SetTrigger("Attack");
            playerPosition = target.transform.position;

            anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);

            float distanceBetweenPlayer = Vector3.Distance(target.position, transform.position) - 0.3f;
            for (int i = 0; i < 3; i++)
            {
                FindObjectOfType<AudioManager>().Play("bossgrowl" + Random.Range(1, 11).ToString());
                FindObjectOfType<AudioManager>().Play("SwingSound" + Random.Range(1, 5).ToString());
                distanceBetweenPlayer = Vector3.Distance(target.position, transform.position) - 0.3f;
                yield return new WaitForSeconds(0.5f);
                if (distanceBetweenPlayer <= agent.stoppingDistance)
                {

                    stats.DealDamage(statsToDamage);
                    //gameObject.transform.position = playerPosition;
                    FindObjectOfType<AudioManager>().Play("SaberHit" + Random.Range(1, 4).ToString());
                    FindObjectOfType<AudioManager>().Play("GettingHit");
                }
            }
        }
        else
        {
            anim.SetTrigger("Shoot");
            playerPosition = target.transform.position;


            anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);

            float distanceBetweenPlayer = Vector3.Distance(target.position, transform.position) - 0.3f;
            distanceBetweenPlayer = Vector3.Distance(target.position, transform.position) - 0.3f;
            
            yield return new WaitForSeconds(0.5f);
                if (distanceBetweenPlayer <= agent.stoppingDistance) //damage
                {

                    stats.DealDamage(statsToDamage);
                    //gameObject.transform.position = playerPosition;
                    
                    target.GetComponent<PlayerHUD>().FadeRedScreen();
                    FindObjectOfType<AudioManager>().Play("GettingHit");
                    yield return new WaitForSeconds(0.3f);
                    target.GetComponent<PlayerHUD>().FadeRedScreen();


            }
            
        }
        
        CountAttack += 1;
        //yield return new WaitForSeconds(2f);
        //gameObject.transform.position = playerPosition;
    }
    private void RotateToTarget()
    {
        //transform.LookAt(target);
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    public void patternManager()
    {
        if (MeleePattern && CountAttack > 2)
        {
            CountAttack = 0;

            isSwitching = true;
            Swapping(meleeWeapons,rangeWeapons);
            FindObjectOfType<AudioManager>().Play("bossgrowl" + Random.Range(1, 11).ToString());
            FindObjectOfType<AudioManager>().Play("SwapToGun");
            MeleePattern = false;

        }
        if(!MeleePattern && CountAttack > 10)
        {
            CountAttack = 0;
            //Destroy(rangeWeapons);
            Swapping(rangeWeapons, meleeWeapons);
            isSwitching = true;
            FindObjectOfType<AudioManager>().Play("bossgrowl" + Random.Range(1, 11).ToString());
            FindObjectOfType<AudioManager>().Play("SwapToSaber");
            MeleePattern = true;
        }
        
    }
    private void Swapping(GameObject OldWeapon, GameObject newWeapon)
    {
        
        anim.SetTrigger("Swaping");
        //yield return new WaitForSeconds(1f);

        currentItemObject = ItemHolder.transform.GetChild(0).gameObject;
        OldWeapon = currentItemObject;
        Destroy(OldWeapon);
        
        Instantiate(newWeapon, ItemHolder);
        

    }

    IEnumerator IncreaseSpeedPerSecond(float waitTime)
    {
        //while agent's speed is less than the speedCap
        while (agent.speed < speedCap)
        {
            //wait "waitTime"
            yield return new WaitForSeconds(waitTime);
            //add 0.5f to currentSpeed every loop 
            agent.speed = agent.speed + 0.5f;
        }
    }


        private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<BossStats>();
        MeleePattern = true;
        target = PlayerController.instance.transform;
        
        
    }
}
