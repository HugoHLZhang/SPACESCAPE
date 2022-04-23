using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    
    //VARIABLE
    //move
    [SerializeField] private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;


    //[SerializeField] private float gravity;

    //jump
    
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpButtonGracePeriod;


    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    //[SerializeField] private Transform groundCheck;
    //[SerializeField] private float groundDistance;
    //[SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    //private bool isGrounded;

    //REFERENCES
    private CharacterController controller;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        originalStepOffset = controller.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if(isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}
        //init player move
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;
        float magnitude = Mathf.Clamp01(move.magnitude) * speed;

        ySpeed += Physics.gravity.y * Time.deltaTime;

        //Vector3 move = transform.right * x + transform.forward * z;



        //change speed
        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else if (move == Vector3.zero)
        {
            speed = 0;
        }

        if (controller.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }



        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }

        }
        else
        {
            controller.stepOffset = 0;
        }


        velocity = move * magnitude;
        velocity.y = ySpeed;

        controller.Move(velocity * Time.deltaTime);

        if(move != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        //controller.Move(move * speed * Time.deltaTime);

        //if(Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
    }

}
