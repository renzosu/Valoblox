using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour 
{
    public CharacterController controller;

    public Animator animator;

    public float speed = 12f;
    public float normalSpeed = 12f;
    public float walkSpeed = 8f;
    public float crouchedSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 2.5f;
    public float normalHeight = 2.5f;
    public float updraftHeight = 8f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isCrouched;

    public float originalHeight;
    public float reducedHeight;

    public AudioSource updraftVFX;

    private bool coolDown = false;
    private float coolDownTime = 10.0f;
    private float coolDownTimer = 0.0f;

    public Text coolDownDisplay;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    void Start() 
    {
        originalHeight = 3.8f;
        reducedHeight = 1.9f;
    }

    // Update is called once per frame
    void Update() 
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * speed * Time.deltaTime);

        if ((Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetButtonDown("Jump")) && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouched = true;
            Crouch();    
            animator.transform.position += new Vector3(0f, 1f, 0f);
            speed = crouchedSpeed;

        } else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouched = false;
            GoUp();
            animator.transform.position -= new Vector3(0f, 1f, 0f);
            speed = normalSpeed;
        }
           
        animator.SetBool("crouched", isCrouched);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }


        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (coolDownTimer == 0) 
            {
                Updraft();
                //Invoke("ResetCoolDown", coolDownTime);
                coolDownTimer = coolDownTime;
            }
        }
        
        coolDownDisplay.text = Mathf.RoundToInt(coolDownTimer).ToString();

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        animator.SetBool("grounded", isGrounded);
    }

    void Crouch()
    {
        //playerCol.height = reducedHeight;
        controller.height = reducedHeight;
        GetComponent<SelfTarget>().TakeDamage(5f);
    }

    void GoUp()
    {
        //playerCol.height = originalHeight;
        controller.height = originalHeight;
    }

    void Updraft()
    {
        if (coolDown == false) 
        {
            jumpHeight = updraftHeight;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpHeight = normalHeight;

            if (updraftVFX != null)
            {
                updraftVFX.Play();
            }
            Invoke("ResetCoolDown", coolDownTime);
            coolDown = true;
        }
    }

    void ResetCoolDown() {
        coolDown = false;
    }
}
