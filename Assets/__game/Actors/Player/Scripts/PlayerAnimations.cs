using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{
    private readonly int VELOCITY_X_INDEX_PARAM = Animator.StringToHash("velocityX");
    private readonly int VELOCITY_Y_INDEX_PARAM = Animator.StringToHash("velocityY");
    private readonly int ON_GROUND_INDEX_PARAM = Animator.StringToHash("OnGround");



    private Rigidbody2D mRigidbody;
    private PlayerController player;
    private PlayerInput input;
    private Animator animator;

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = Mathf.Abs(input.AxisMoveX);
        float Y = mRigidbody.velocity.y;

        animator.SetBool(ON_GROUND_INDEX_PARAM, player.IsOnTheGround);
        animator.SetFloat(VELOCITY_X_INDEX_PARAM, X );
        animator.SetFloat(VELOCITY_Y_INDEX_PARAM, Y);
    }
}
