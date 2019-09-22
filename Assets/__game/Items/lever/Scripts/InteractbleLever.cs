using UnityEngine;

[RequireComponent(typeof(LeverController))]
public class InteractbleLever : CommonInteractableMonoBehaviour
{

    private LeverController leverController;

    protected override void Init()
    {
        leverController = GetComponent<LeverController>();
    }

    public override void Interact()
    {
        if (IsPlayerEnter) {
            leverController.ChangeStateState();
        }
        else {
            Player.SetInteractable(null);
        }
    }


    private void FixedUpdate()
    {
        ChekOnPlayerEnter();
    }
}
