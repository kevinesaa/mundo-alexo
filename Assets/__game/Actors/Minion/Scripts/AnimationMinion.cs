using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMinion : MonoBehaviour
{
    private Animator animator;
    private MinionController minion;

    private readonly int WALKING_ANIM_PARAM = Animator.StringToHash("walking");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        minion = GetComponent<MinionController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(WALKING_ANIM_PARAM, minion.IsMoving);
    }
}
