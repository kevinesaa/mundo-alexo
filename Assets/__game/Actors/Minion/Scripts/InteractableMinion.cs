using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MinionController))]
public class InteractableMinion : CommonInteractableMonoBehaviour
{
    private MinionController minion;

    protected override void Init()
    {
        minion = GetComponent<MinionController>();   
    }

    private void FixedUpdate()
    {
        if (!minion.IsMoving)
            ChekOnPlayerEnter();
    }

    public override void Interact()
    {
        Player.SetInteractable(null);
        if (IsPlayerEnter)
        {
            if (minion.hat != null)
                minion.hat.SetActive(true);
            minion.IsMoving = true;
            IsPlayerEnter = false;
            Player = null;
        }
    }
}
