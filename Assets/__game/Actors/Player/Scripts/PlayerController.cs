using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public bool seeToRight = true;
    public float baseSpeed = 5f;
    public float baseJumpForce = 5f;
    public float maxFallVelocity = -25f;
    
    public float coyoteDuration = 0.05f;
    public float groundDistance = 0.2f;
    public Transform transfromGroundLeftCheck;
    public Transform transfromGroundRightCheck;

    private LayerMask layerGround;
    private PlayerInput playerInput;
    private Rigidbody2D mRigidbody2D;
    private float coyoteTime;
    private bool isTochingGround;
    private IInteractable mInteractable;

    public void SetInteractable(IInteractable interactable)
    {
        mInteractable = interactable;
    }

    public void ResetDirection()
    {
        int direction = seeToRight ? 1 : -1;
        Vector3 v = transform.right;
        v.x = direction;
        transform.right = v;
    }

    private void Awake()
    {
        layerGround = LayerMask.GetMask("Ground");
    }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        ResetDirection();

        mRigidbody2D = GetComponent<Rigidbody2D>();

        Flip();
    }

    private void FixedUpdate()
    {
        Flip();
        CheckPhysics();
        AirMovement();
        Movement();
        Interactions();
    }

    private void Flip()
    {
        if (playerInput.AxisMoveX * transform.right.x < 0)
        {
            transform.Rotate(0, 180, 0);
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
        if (playerInput.JumpButtonPressed  && (isTochingGround || coyoteTime > Time.time))
        {
            float gravityScale = mRigidbody2D.gravityScale;
            Vector2 velocity = mRigidbody2D.velocity;
            velocity.y = 0;
            mRigidbody2D.velocity = velocity;
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

        if (isTochingGround)
            coyoteTime = Time.time + coyoteDuration;
    }

    private void Interactions()
    {
        if (mInteractable != null && playerInput.ActionButtonPressed)
        {
            mInteractable.Interact();
        }
    }
}
