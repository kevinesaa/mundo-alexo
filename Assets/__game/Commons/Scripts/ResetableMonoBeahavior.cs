using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResetableMonoBeahavior : MonoBehaviour
{
    private Vector3 positon;
    private Quaternion rotation;
    private Vector3 scale;

    private void Awake()
    {
        OnInit();
    }

    protected virtual void OnInit()
    {
        positon = transform.position;
        rotation = transform.rotation;
        scale = transform.localScale;
    }

    public virtual void MyReset()
    {
        transform.position = positon;
        transform.rotation = rotation;
        transform.localScale = scale;
        gameObject.SetActive(true);
    }
}
