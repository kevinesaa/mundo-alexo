using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public bool seeToRight = true;
    public float baseSpeed = 5f;
    public float baseJumpForce = 5f;
    public float maxFallVelocity = -25f;

    public float groundDistance = 0.2f;
    public Transform transfromGroundLeftCheck;
    public Transform transfromGroundRightCheck;
    public LayerMask layerGround;

    private int direction;
    private PlayerInput playerInput;
    private Rigidbody2D mRigidbody2D;
    private bool isTochingGround;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        direction = seeToRight ? 1 : -1;

        mRigidbody2D = GetComponent<Rigidbody2D>();
        Flip();
    }

    private void FixedUpdate()
    {
        Flip();
        CheckPhysics();
        AirMovement();
        Movement();

    }

    private void Flip()
    {
        if (playerInput.AxisMoveX * direction < 0)
        {
            transform.Rotate(0, 180, 0);
            direction *= -1;
        }
    }

    private void CheckPhysics()
    {
        
        RaycastHit2D groundLeftCheckHit = Physics2D.Raycast(transfromGroundLeftCheck.position, Vector2.down, groundDistance, layerGround);
        RaycastHit2D groundRightCheckHit = Physics2D.Raycast(transfromGroundRightCheck.position, Vector2.down, groundDistance, layerGround);
        isTochingGround = groundLeftCheckHit || groundRightCheckHit;
#if UNITY_EDITOR
        Color colorLeft = groundLeftCheckHit ? Color.green : Color.red;
        Debug.DrawRay(transfromGroundLeftCheck.position,Vector2.down*groundDistance,colorLeft);
        Color colorRight = groundRightCheckHit ? Color.green : Color.red;
        Debug.DrawRay(transfromGroundRightCheck.position, Vector2.down * groundDistance, colorRight);
#endif
    }

    private void AirMovement()
    {
        if (isTochingGround && playerInput.JumpButtonPressed)
        {
            mRigidbody2D.AddForce(baseJumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        if (mRigidbody2D.velocity.y < maxFallVelocity)
        {
            Vector2 currentVelocity = mRigidbody2D.velocity;
            currentVelocity.y = maxFallVelocity;
            mRigidbody2D.velocity = currentVelocity;
        }
    }

    private void Movement()
    {
        float xVelocity = baseSpeed * playerInput.AxisMoveX;
        Vector2 currentVelocity = mRigidbody2D.velocity;
        currentVelocity.x = xVelocity;
        mRigidbody2D.velocity = currentVelocity;
    }
}
