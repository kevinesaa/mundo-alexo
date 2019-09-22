using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionableElement : MonoBehaviour
{
    public LeverController lever;
    public bool initialStatus;
    public bool Status { get; private set; }

    protected virtual void OnInit()
    {
        Status = initialStatus;
    }

    private void Awake()
    {
        if(lever!=null)
        {
            lever.OnLeverChangeCallback += ActinableSourceChange;
        }
        OnInit();
    }

    private void OnDestroy()
    {
        if (lever != null)
        {
            lever.OnLeverChangeCallback -= ActinableSourceChange;
        }
    }

    protected virtual void ActinableSourceChange(bool activate)
    {
        Status = activate;
    }

    public virtual void MyReset()
    {
        Status = initialStatus;
    }
}
