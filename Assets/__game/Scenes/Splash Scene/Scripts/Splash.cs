using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Splash : MonoBehaviour
{
    [SceneInBuildSettingsProperty(typeof(SceneInBuildSettingListHelper),"AllScene")]
    public SceneInBuildConfigContainer nextScene;
    public int index;
    public float delayInSeconds = 1.5f;
    public Slider loadingBar;

    private AsyncOperation scenaAsyncOperation = null;

    void Start()
    {
        
        if (loadingBar != null)
        {
            loadingBar.interactable = false;
            loadingBar.value = 0;
            loadingBar.minValue = 0;
            loadingBar.maxValue = 1;
        }
        Invoke("LoadScene", delayInSeconds);
    }

    
    void OnGUI()
    {
        if (scenaAsyncOperation != null && loadingBar != null)
        {
            float progress=scenaAsyncOperation.progress;
            loadingBar.value = progress;
        }
    }

    private void LoadScene()
    {
        
        scenaAsyncOperation = SceneManager.LoadSceneAsync(index);
    }

    


}
