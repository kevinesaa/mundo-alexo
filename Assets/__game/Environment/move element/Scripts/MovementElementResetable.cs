using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveElementByAction))]
public class MovementElementResetable : ResetableMonoBeahavior
{
    private MoveElementByAction moveElementByAction;

    protected override void OnInit()
    {
        moveElementByAction = GetComponent<MoveElementByAction>();
    }

    public override void MyReset()
    {
        moveElementByAction.MyReset();
    }
}
