using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class ResetablePlayer : ResetableMonoBeahavior
{
    private PlayerController player;

    protected override void OnInit()
    {
        base.OnInit();
        player = GetComponent<PlayerController>();
    }

    public override void MyReset()
    {
        base.MyReset();
        player.ResetDirection();
    }
}
