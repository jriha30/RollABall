using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    public bool isSprinting;
    public bool isFalling;
    public bool isMoving;

    public Transform playerCamera;

    private Rigidbody rb;

    public float jumpForce;
    public float speedForce;

    // accerleration calculation
    private float currentVelocity;
    private float previousVelocity;
    private float currentTime;
    private float previousTime;
    private float acceleration;

    public float sprintMult;
    public float fallingMult;

    private bool isForward;
    private bool isBackward;
    private bool isLeft;
    private bool isRight;

    public Map_Generator map;

    public Vector3 movementVector;

    private Walking_Sound walkingSound;

    private Player_Components components;

    public respawn respawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        playerCamera = transform.Find("Main Camera");

        currentVelocity = rb.velocity.y;
        previousVelocity = rb.velocity.y;
        currentTime = Time.time;
        previousTime = Time.time;
        acceleration = 0;

        movementVector = new Vector3(0, 0, 0);

        sprintMult = 1.5f;
        fallingMult = 0.75f;

        jumpForce = 3f;
        speedForce = .1f;

        isForward = false;
        isBackward = false;
        isLeft = false;
        isRight = false;

        walkingSound = GetComponent<Walking_Sound>();

        components = GetComponent<Player_Components>();
    }

    private void Update()
    {
        GetPlayerInput();
        CheckMoving();
        ChangeCamera();
    }

    void FixedUpdate()
    {
        CheckFalling();
        MovePlayer();
        StaminaChanges();
        MagicChanges();
        ResetValues();
    }

    private void CheckMoving()
    {
        if(rb.velocity != Vector3.zero)
        {
            isMoving = true;
        }
    }

    private void StaminaChanges()
    {
        StaminaBar sb = components.staminaBar;
        if (isSprinting)
        {
            components.currentStamina -= sb.emptyRate;
        }
        else if (isMoving)
        {
            components.currentStamina += sb.recoverRate / 5;
        }
        else
        {
            components.currentStamina += sb.recoverRate;
        }
    }

    private void MagicChanges()
    {
        if(components.currentRoom != null && components.currentMagic < components.maxMagic && !components.currentRoom.GetComponent<Room_Components>().isCleared)
        {
            components.currentMagic += components.magicBar.recoverRate;
        }
    }

    void LateUpdate()
    {
        if (components.currentHitpoints > components.maxHitpoints)
        {
            components.currentHitpoints = components.maxHitpoints;
        }
        else if(components.currentHitpoints < 0)
        {
            components.currentHitpoints = 0;
        }
        if (components.currentMagic > components.maxMagic)
        {
            components.currentMagic = components.maxMagic;
        }
        else if(components.currentMagic < 0)
        {
            components.currentMagic = 0;
        }
        if(components.currentStamina > components.maxStamina)
        {
            components.currentStamina = components.maxStamina;
        }
        else if(components.currentStamina < 0)
        {
            isSprinting = false;
            components.currentStamina = 0;
        }

        if (!isMoving)
        {
            isSprinting = false;
        }

        if(components.currentHitpoints == 0 && !Player_Components.isDead)
        {
            respawn.ClearAreaOnDeath();
        }
    }


    private void GetPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isSprinting)
                isSprinting = true;
            else
                isSprinting = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            isForward = true;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isBackward = true;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isLeft = true;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
            isMoving = true;
        }
    }

    private void ChangeCamera()
    {
        if (isSprinting)
        {
            Camera.main.fieldOfView = 90.0f;
        }
        else
        {
            Camera.main.fieldOfView = 70.0f;
        }
    }
    private void CheckFalling()
    {
        currentVelocity = rb.velocity.y;
        currentTime = Time.time;

        acceleration = (currentVelocity - previousVelocity) / (currentTime - previousTime);

        if (acceleration < -1)
        {
            isFalling = true;
        }
        else if (acceleration >= -1)
        {
            isFalling = false;
        }
        previousVelocity = currentVelocity;
        previousTime = currentTime;
    }
    private void MovePlayer()
    {
        movementVector = new Vector3(0, 0, 0);

        if (isForward)
            movementVector += Vector3.forward;
        if (isBackward)
            movementVector += Vector3.back;
        if (isLeft)
            movementVector += Vector3.left;
        if (isRight)
            movementVector += Vector3.right;

        movementVector.Normalize();

        if (isSprinting)
            movementVector *= sprintMult;
        if (isFalling)
            movementVector *= fallingMult;

        movementVector *= speedForce;
        transform.Translate(movementVector);
    }

    private void ResetValues()
    {
        isForward = false;
        isBackward = false;
        isLeft = false;
        isRight = false;

        isMoving = false;
    }
}