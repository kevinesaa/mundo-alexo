using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null || !Instance.Equals(this))
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }


}
