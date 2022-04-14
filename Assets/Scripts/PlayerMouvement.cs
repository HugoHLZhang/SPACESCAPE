using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController controller;

    public Animator animator;
    public float walkSpeed;
    public float runSpeed;
    public float runBuildUpSpeed;
    private float movementSpeed;
    private bool isHitting;
    public float isHittingValue;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float SceneStartTime;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
   
    
    bool isGrounded;
    float animVelocity;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SceneStartTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        SceneStartTime += 0.03f;

        isHittingValue = -3 * Mathf.Sin(0.5f * (SceneStartTime - 2)) + 1;

        Debug.Log(Time.time);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movementSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.Mouse0))
        {
            isHitting = true;
            animator.SetBool("isHitting", isHitting);
        }

        else
        {
            isHitting = false;
            animator.SetBool("isHitting", isHitting);
        }




        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        animator.SetFloat("MovementSpeed", movementSpeed);
        animator.SetFloat("isHittingValue", isHittingValue);

        SetMovementSpeed();
        
    }
    public void SetMovementSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        }
        else
        {
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
        }
    }

}

