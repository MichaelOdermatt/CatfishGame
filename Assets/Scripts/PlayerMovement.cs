using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float airSpeed;
    [SerializeField]
    private float rotationSpeed;

    private bool isJumping;
    private bool isGrounded;
    private Vector3 bottomOfPlayer;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;

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

        calculateBottomOfPlayer();
        isGrounded = Physics.OverlapSphere(bottomOfPlayer, groundCheckRadius, whatIsGround).Length != 0;

        GroundMovement(ZRotation, XRotation);
        if (!isGrounded)
        {
            AirMovement(ZMovement, XMovement);
        }

        if (jump == true && isGrounded)
        {
            Jump();
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
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

    // fix weird double jump issue
    private void Jump()
    {
        rigidbody.velocity = Vector3.up * jumpForce;
    }

    // TODO: rework this
    private void calculateBottomOfPlayer()
    {
        var offset = 0.5f;
        var x = rigidbody.position.x;
        var y = rigidbody.position.y;
        var z = rigidbody.position.z;

        bottomOfPlayer = new Vector3(x, y - offset, z);
    }
}
