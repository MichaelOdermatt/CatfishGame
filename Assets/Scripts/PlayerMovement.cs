using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    // basic movement
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float airSpeed;
    [SerializeField]
    private float rotationSpeed;

    // jumping
    private bool isJumping;
    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;
    [SerializeField]
    private float jumpCooldownTime;
    private float jumpCooldownTimeCounter;
    private bool isJumpCooldownActive = false;

    // checking for ground
    private bool isGrounded;
    [SerializeField]
    private float groundCheckOffset;
    private Vector3 bottomOfPlayer;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask whatIsGround;

    private void Start()
    {
        calculateBottomOfPlayer();
    }

    private void Update()
    {
        var ZMovement = Input.GetAxis("ZMovement");
        var XMovement = Input.GetAxis("XMovement");

        var ZRotation = Input.GetAxis("ZRotation");
        var XRotation = Input.GetAxis("XRotation");

        var jump = Input.GetKeyDown(KeyCode.Space);

        if (jump)
        {
            AttemptJump();
        }

        // the rest of this method should probably be in fixed update
        GroundMovement(ZRotation, XRotation);

        if (!isGrounded)
        {
            AirMovement(ZMovement, XMovement);
        }

        if (isJumping)
        {
            ContinueJump();
        }

    }

    private void AirMovement(float zMovement, float xMovement)
    {
        if (zMovement != 0)
        {
            rigidbody.AddForce(Vector3.forward * airSpeed * zMovement);
        }

        if (xMovement!= 0)
        {
            rigidbody.AddForce(Vector3.right * airSpeed * xMovement);
        }
    }

    private void GroundMovement(float zRotation, float xRotation)
    {
        if (zRotation != 0)
        {
            rigidbody.AddTorque(Vector3.right * rotationSpeed * zRotation, ForceMode.Acceleration);
        }

        if (xRotation != 0)
        {
            rigidbody.AddTorque(Vector3.back * rotationSpeed * xRotation, ForceMode.Acceleration);
        }
    }

    private void Jump()
    {
        rigidbody.velocity = Vector3.up * jumpForce;
    }

    private void ContinueJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0 && isJumping)
            {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false; 
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void AttemptJump()
    {
        calculateBottomOfPlayer();
        isGrounded = Physics.OverlapSphere(bottomOfPlayer, groundCheckRadius, whatIsGround).Length != 0;

        if (isGrounded && !isJumpCooldownActive)
        {
            Jump();
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
    }

    private void calculateBottomOfPlayer()
    {
        var x = rigidbody.position.x;
        var y = rigidbody.position.y;
        var z = rigidbody.position.z;

        bottomOfPlayer.x = x;
        bottomOfPlayer.y = y - groundCheckOffset;
        bottomOfPlayer.z = z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartJumpCooldownTimer();
    }

    private void StartJumpCooldownTimer()
    {
        jumpCooldownTimeCounter = jumpCooldownTime;
        StartCoroutine(JumpCooldownTick());
    }

    private IEnumerator JumpCooldownTick()
    {
        isJumpCooldownActive = true;
        while (jumpCooldownTimeCounter > 0)
        {
            jumpCooldownTimeCounter -= Time.deltaTime;
            yield return null;
        }
        isJumpCooldownActive = false;
    }
}
