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

    private JumpState jumpState = JumpState.HasLanded;
    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;
    [SerializeField]
    private float jumpCooldownTime;
    private float jumpCooldownTimeCounter;
    private bool isJumpCooldownActive = false;

    // is true if the area under the player is ground
    private bool isGrounded;
    [SerializeField]
    // how far underneath the player the game will check for ground
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

        calculateBottomOfPlayer();
        isGrounded = Physics.OverlapSphere(bottomOfPlayer, groundCheckRadius, whatIsGround).Length != 0;

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

        if (jumpState == JumpState.IsJumping)
        {
            if (jump)
            {
                ContinueJump();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpState = JumpState.IsFalling;
            }
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
        if (jumpTimeCounter > 0 && jumpState == JumpState.IsJumping)
        {
            Jump();
            jumpTimeCounter -= Time.deltaTime;
        } else
        {
            jumpState = JumpState.IsFalling;
        }
    }

    private void AttemptJump()
    {
        if (isGrounded && !isJumpCooldownActive && jumpState == JumpState.HasLanded)
        {
            Jump();
            jumpState = JumpState.IsJumping;
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
        if (isGrounded)
        {
            StartJumpCooldownTimer();
            jumpState = JumpState.HasLanded;
        } else
        {
            StartCoroutine(ExecuteAfterTime.Exectute(RecheckHasLanded, jumpCooldownTime));
        }
    }

    /// <summary>
    /// Need to recheck if the player has landed, as sometimes the player will land half on the edge of
    /// the keyboad and isGrounded will return false so we recheck until the player has
    /// managed to wiggle themselves free
    /// </summary>
    private void RecheckHasLanded()
    {
        if (isGrounded)
        {
            jumpState = JumpState.HasLanded;
        } else
        {
            StartCoroutine(ExecuteAfterTime.Exectute(RecheckHasLanded, jumpCooldownTime));
        }
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

    private enum JumpState
    {
        IsJumping,
        IsFalling,
        HasLanded,
    }
}
