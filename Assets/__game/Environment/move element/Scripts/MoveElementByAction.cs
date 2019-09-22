using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElementByAction : ActionableElement
{
    public Vector3 destOffset;
    public float movementSpeed;
    
    private Vector3 sourcePosition;
    private Vector3 swapperPosition;
    private Vector3 destPosition;

    private void FixedUpdate()
    {
         transform.position = Vector3.MoveTowards(transform.position, swapperPosition, movementSpeed);
    }

    protected override void ActinableSourceChange(bool activate)
    {
        base.ActinableSourceChange(activate);
        if (Status == initialStatus)
        {
            swapperPosition = sourcePosition;
        }
        else
        {
            swapperPosition = destPosition;
        }
    }

    public override void MyReset()
    {
        base.MyReset();
        swapperPosition = sourcePosition;
        transform.position = sourcePosition;
    }

    protected override void OnInit()
    {
        sourcePosition = transform.position;
        swapperPosition = transform.position;
        destPosition = sourcePosition + destOffset;
    }
}
