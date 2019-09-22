using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommonInteractableMonoBehaviour : MonoBehaviour, IInteractable
{

    public float radiusInteraction = 0.5f;
    public Vector3 radiusOffset = Vector2.zero;

    public bool IsPlayerEnter { get; protected set; }
    public PlayerController Player { get; protected set; }

    protected abstract void Init();
    public abstract void Interact();

    private LayerMask layerPlayer;

    private void Awake()
    {
        layerPlayer = LayerMask.GetMask("Player");
        Init();
    }


    protected void ChekOnPlayerEnter()
    {
        Collider2D colliderRadius = Physics2D.OverlapCircle(transform.position + radiusOffset, radiusInteraction, layerPlayer);
        IsPlayerEnter = colliderRadius;
        if (IsPlayerEnter)
        {
            if (Player == null)
            {
                Player = colliderRadius.gameObject.GetComponent<PlayerController>();
            }
            Player.SetInteractable(this);
        }
    }
}
