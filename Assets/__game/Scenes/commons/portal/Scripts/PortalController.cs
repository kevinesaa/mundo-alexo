using System;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public event Action OnMinionEnter;

    private const string TAG_MINION = "Minions";
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TAG_MINION))
        {
            MinionController minion = other.GetComponent<MinionController>();
            minion.EnterPortal();
            if (OnMinionEnter != null)
                OnMinionEnter();
        }
    }
}
