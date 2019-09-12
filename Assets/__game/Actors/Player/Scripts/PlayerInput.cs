using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class PlayerInput : MonoBehaviour
{
    public bool ActionButtonPressed { get; private set; }
    public bool ActionButtonKeepPressing { get; private set; }
    public bool JumpButtonPressed { get; private set; }
    public bool JumpButtonKeepPressing { get; private set; }
    public float AxisMoveX { get; private set; }
    private bool readyToCleanInput;


    void Update()
    {
        CleanInput();
        ProcessInput();
        FixInput();
    }

    private void FixedUpdate()
    {
        readyToCleanInput = true;
    }

    private void CleanInput() {
        if (!readyToCleanInput)
            return;

        AxisMoveX = 0;
        ActionButtonPressed = false;
        ActionButtonKeepPressing = false;
        JumpButtonPressed = false;
        JumpButtonKeepPressing = false;
        readyToCleanInput = false;
    }

    private void ProcessInput()
    {
        ActionButtonPressed = ActionButtonPressed || Input.GetButtonDown("Action");
        ActionButtonKeepPressing = ActionButtonKeepPressing || Input.GetButton("Action");
        JumpButtonPressed = JumpButtonPressed || Input.GetButtonDown("Jump");
        JumpButtonKeepPressing = JumpButtonKeepPressing || Input.GetButton("Jump");
        AxisMoveX += Input.GetAxis("Horizontal");
    }

    private void FixInput()
    {
       AxisMoveX = Mathf.Clamp(AxisMoveX, -1, 1);
    }
}
