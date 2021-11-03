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
    }

    private void Update()
    {
        GetPlayerInput();
        ChangeCamera();
    }

    void FixedUpdate()
    {
        CheckFalling();
        MovePlayer();
        ResetValues();
    }


    private void GetPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isSprinting)
                isSprinting = false;
            else
                isSprinting = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //foreach (GameObject i in Get_Room.currentRoom.GetComponent<Room_Components>().listOfWalls)
            //{
            //    BoxCollider currCollider = i.GetComponent<Doorway_Components>().doorway.GetComponent<BoxCollider>();
            //    MeshRenderer currRenderer = i.GetComponent<Doorway_Components>().doorway.GetComponent<MeshRenderer>();
            //    if (currCollider.enabled == false)
            //    {
            //        currCollider.enabled = true;
            //        currRenderer.enabled = true;
            //    }
            //    else
            //    {
            //        currCollider.enabled = false;
            //        currRenderer.enabled = false;
            //    }
            //}
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