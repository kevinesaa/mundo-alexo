using System;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public event Action OnMinionEnter;

    private const string TAG_MINION = "Minions";
    private readonly int MINION_ENTER_INDEX_ANIM_PARAM = Animator.StringToHash("minion_enter");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TAG_MINION))
        {
            MinionController minion = other.GetComponent<MinionController>();
            minion.EnterPortal();
            animator.SetTrigger(MINION_ENTER_INDEX_ANIM_PARAM);
            if (OnMinionEnter != null)
                OnMinionEnter();
        }
    }
}
