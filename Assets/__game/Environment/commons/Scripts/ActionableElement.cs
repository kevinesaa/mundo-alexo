using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionableElement : MonoBehaviour
{
    public LeverController[] levers;
    public bool initialStatus;
    public bool Status { get; private set; }

    protected virtual void OnInit()
    {
        Status = initialStatus;
    }

    private void Awake()
    {
        if(levers!=null && levers.Length > 0)
        {
            foreach (LeverController it in levers)
            {
                it.OnLeverChangeCallback += ActinableSourceChange;
            }
            
        }
        OnInit();
    }

    private void OnDestroy()
    {
        if (levers != null && levers.Length > 0)
        {
            foreach (LeverController it in levers)
            {
                it.OnLeverChangeCallback -= ActinableSourceChange;
            }

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
