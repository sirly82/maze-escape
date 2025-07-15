using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float moveSpeed = 5f;
    public float snapRotationAngle = 90f;
    public float jumpForce = 5f;

    public float gravity = -9.81f;
    private float verticalVelocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // Pastikan CharacterController memiliki height yang sesuai
        controller.height = 1.0f; // Sesuaikan dengan kebutuhan
        controller.center = new Vector3(0, 0.5f, 0); // Sesuaikan dengan kebutuhan
    }

    // Update is called once per frame
    void Update()
    {
        // Ambil input arah dari keyboard
        float horizontal = Input.GetAxis("Horizontal"); // A/D atau ← →
        float vertical = Input.GetAxis("Vertical"); // W/S atau ↑ ↓

        // Snap rotation
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -snapRotationAngle, 0); // Rotasi kiri 90 derajat
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, snapRotationAngle, 0); // Rotasi kanan 90 derajat
        }

        // Movement
        bool isMoving = vertical != 0;
        bool isForward = vertical > 0;

        bool isJump = false;
        bool isTurning = false;
        bool isTurningRight = false;

        if(isMoving)
        {
            Vector3 forwardMove = transform.forward * vertical * moveSpeed;
            controller.Move(forwardMove * Time.deltaTime);
        }

        // Jump
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                verticalVelocity = jumpForce;
                isJump = true;
            }
            else
            {
                verticalVelocity = -1f; // Tetap menempel di tanah
                isJump = false;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        // Aplikasikan gravitasi
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);

        // Animation
        animator.SetBool("isGrounded", controller.isGrounded);
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isForward", isForward);
        animator.SetBool("isTurn", isTurning);
        animator.SetBool("isTurnRight", isTurningRight);
        animator.SetBool("isJump", isJump);
    }
}
