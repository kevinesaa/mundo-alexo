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
        if (minion.hat != null)
            minion.hat.SetActive(false);
    }

    public override void MyReset()
    {
        base.MyReset();
        minion.IsMoving = false;
        if (minion.hat != null)
            minion.hat.SetActive(false);
    }

}
