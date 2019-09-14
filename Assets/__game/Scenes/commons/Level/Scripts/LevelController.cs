using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int MiniontEnterPortalCount { get; private set; }
    public int MinionCount { get; private set; }

    private PortalController portal;
    private List<ResetableMonoBeahavior> resetableList;

    public bool AllMinionsPassThePortal { get { return MiniontEnterPortalCount >= MinionCount; } }

    void Awake()
    {
        MinionController[] allTheMinions = GameObject.FindObjectsOfType<MinionController>();
        PlayerController[] player = GameObject.FindObjectsOfType<PlayerController>();
        PortalController[] portal = GameObject.FindObjectsOfType<PortalController>();

        if (allTheMinions.Length < 0)
        {
            throw new ArgumentException("The level need a lest one minion");
        }

        if (player.Length != 1)
        {
            throw new ArgumentException("The level need just one player");
        }

        if (portal.Length != 1)
        {
            throw new ArgumentException("The level need just one portal");
        }

        this.portal = portal[0];
        this.portal.OnMinionEnter += OnMinionEnterPortal;

        MinionCount = allTheMinions.Length;
        MiniontEnterPortalCount = 0;

        ResetableMonoBeahavior[] resetableObjects = GameObject.FindObjectsOfType<ResetableMonoBeahavior>();
        resetableList = new List<ResetableMonoBeahavior>(resetableObjects);
    }

    private void OnDestroy()
    {
        this.portal.OnMinionEnter -= OnMinionEnterPortal;
    }

    public void ResetLevel()
    {
        MiniontEnterPortalCount = 0;
        resetableList.ForEach(E => E.MyReset());
    }

    private void OnMinionEnterPortal()
    {
        MiniontEnterPortalCount++;
        if (AllMinionsPassThePortal)
        {

        }
    }
}
