using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float baseSpeed = 24f;
    private float speed;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;
    public float sprintMultiplier = 1.65f;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private void Start()
    {
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            //velocity = Vector3.zero;
            velocity.y = -2f;
        }

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMove + transform.forward * zMove;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintMultiplier * baseSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //speed = 24f;
            speed = baseSpeed;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
