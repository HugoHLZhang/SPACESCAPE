using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;

    
    private bool isFire;
    private bool isSlash;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float saberRange = 2f;
    //public GameObject player;
    public EquipmentManager inventory;
    public Camera fpscam;
    //public ParticleSystem fireEffect;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    [Header("Gravity")]
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isCharacterGrounded = false;
    private  ParticleSystem particleSystem;
    private Vector3 velocity = Vector3.zero;

    private Animator anim;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void Update()
    {
        HandleIsGrounded();
        HandleGravity();
        HandleJumping();
        HandleRunning();
        HandleMovement();
        HandleAnimations();
        HandleIsFiring();
        //Fire();
        HandleSaberAttack();
        //Cut();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = moveDirection.normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleSaberAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            isSlash = true;

        }
        else
        {
            isSlash = false;
        }

        anim.SetBool("isSlashing", isSlash);
    }
    //private void Slash()
    //{
    //    if (GameObject.Find("Player").GetComponent<EquipmentManager>().SaberEquiped == true)
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, saberRange))
    //        {
                
    //            Target target = hit.transform.GetComponent<Target>();
    //            CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();

    //            if (hit.transform.tag == "Destroyable" && target != null)
    //            {
    //                target.TakeDamage(damage);
    //                Debug.Log(damage);
    //            }
    //            if (hit.transform.tag == "Destroyable" && enemyStats != null)
    //            {
    //                enemyStats.TakeDamage((int)damage);
    //                Debug.Log(damage);
    //            }
    //        }
    //    }
    //}
    //private void Cut()
    //{
    //    if (isSlash && anim.GetBool("isSlashing") == true)
    //    {
    //        Slash();
    //    }
    //}
    private void HandleIsFiring()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            
            isFire = true;
            
        }
        else
        {
            isFire = false;
        }

        anim.SetBool("isFiring", isFire);
    }
    //private void Fire()
    //{
    //    if(isFire && anim.GetBool("isFiring") == true)
    //    {
    //        Shoot();
    //    }
    //}
    //private void Shoot()
    //{
    //    //fireEffect.Play();
    //    if (GameObject.Find("Player").GetComponent<EquipmentManager>().GunEquiped == true)
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
    //        {
    //            Debug.Log(hit.transform.name);
    //            Target target = hit.transform.GetComponent<Target>();
    //            CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();

    //            if (hit.transform.tag == "Destroyable" && target != null)
    //            {
    //                target.TakeDamage(damage);
    //            }
    //            if (hit.transform.tag == "Destroyable" && enemyStats != null)
    //            {
    //                enemyStats.TakeDamage((int)damage);
    //            }
    //        }
    //    }
    //}

    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
        }
    }

    private void HandleAnimations()
    {
        if (moveDirection == Vector3.zero)
        {
            anim.SetFloat("Speed", 0f, 0.2f, Time.deltaTime);
        }
        else if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 0.5f, 0.2f, Time.deltaTime);
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
        }
    }

    private void HandleIsGrounded()
    {
        isCharacterGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }

    private void HandleGravity()
    {
        if (isCharacterGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCharacterGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void GetReferences()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void InitVariables()
    {
        moveSpeed = walkSpeed;
    }

}
