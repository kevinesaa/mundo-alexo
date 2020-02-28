using System;
using UnityEngine;
using UnityEngine.Events;

public class LeverController : MonoBehaviour
{

    public event Action<bool> OnLeverChangeCallback;
    public bool intialState = false;

    public bool State { get; private set; }

    private readonly static int LEVER_STATE_ANIM_ID = Animator.StringToHash("lever_state");

    private Animator mAnimator;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        MyReset();
    }

    private void Update()
    {
        mAnimator.SetBool(LEVER_STATE_ANIM_ID, State);
    }

    public void MyReset() {
        State = intialState;
    }

    public void ChangeStateState()
    {

        State = !State;
        //sound change
        if (OnLeverChangeCallback != null) {
            OnLeverChangeCallback(State);
        }
           
    }
}
