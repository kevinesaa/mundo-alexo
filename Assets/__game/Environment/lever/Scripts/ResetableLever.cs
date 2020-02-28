using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LeverController))]
public class ResetableLever : ResetableMonoBeahavior
{
    private LeverController leverController;

    protected override void OnInit()
    {
        base.OnInit();
        leverController = GetComponent<LeverController>();
    }

    public override void MyReset()
    {
        base.MyReset();
        leverController.MyReset();
    }

}
