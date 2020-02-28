using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int MiniontEnterPortalCount { get; private set; }
    public int MinionCount { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private PortalController portal;
    private List<ResetableMonoBeahavior> resetableList;

    public bool AllMinionsPassThePortal { get { return MiniontEnterPortalCount >= MinionCount; } }

    void Awake()
    {
        MinionController[] allTheMinions = GameObject.FindObjectsOfType<MinionController>();
        PlayerController[] player = GameObject.FindObjectsOfType<PlayerController>();
        PortalController[] portal = GameObject.FindObjectsOfType<PortalController>();
        cinemachineVirtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
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

        IntCamera(player[0]);

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

    private void IntCamera(PlayerController player)
    {
        cinemachineVirtualCamera.Follow = player.transform;
        LensSettings settings = cinemachineVirtualCamera.m_Lens;
        settings.OrthographicSize = 5;
        cinemachineVirtualCamera.m_Lens = settings;
        CinemachineFramingTransposer cinemachineFramingTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        cinemachineFramingTransposer.m_LookaheadTime = 0.5f;
        cinemachineFramingTransposer.m_LookaheadSmoothing = 15;
        cinemachineFramingTransposer.m_XDamping = 1;
        cinemachineFramingTransposer.m_YDamping = 1;
        cinemachineFramingTransposer.m_ZDamping = 1;
        cinemachineFramingTransposer.m_DeadZoneWidth = 0.1f;
        cinemachineFramingTransposer.m_DeadZoneHeight = 0.2f;
        cinemachineFramingTransposer.m_ScreenX = 0.5f;
        cinemachineFramingTransposer.m_ScreenY = 0.8f;
        cinemachineFramingTransposer.m_BiasX = 0;
        cinemachineFramingTransposer.m_BiasY = 0;
        cinemachineFramingTransposer.m_CenterOnActivate = true;
    }

    private void OnMinionEnterPortal()
    {
        MiniontEnterPortalCount++;
        if (AllMinionsPassThePortal)
        {
            Scene currentScene=SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        }
    }
}
