using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MinionController))]
public class ResetableMinion : ResetableMonoBeahavior
{

    private MinionController minion;

    protected override void OnInit()
    {
        base.OnInit();
        minion = GetComponent<MinionController>();
    }

    public override void MyReset()
    {
        base.MyReset();
        minion.IsMoving = false;
    }

}
