using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SceneInBuildSettingsProperty(typeof(SceneInBuildSettingListHelper), "AllScene")]
    public SceneInBuildConfigContainer nextScene;
    public int index;
    public Slider loadingBar;

    private AsyncOperation scenaAsyncOperation = null;

    private void Start()
    {
        if (loadingBar != null)
        {
            loadingBar.interactable = false;
            loadingBar.value = 0;
            loadingBar.minValue = 0;
            loadingBar.maxValue = 1;
            loadingBar.gameObject.SetActive(false);
        }
    }
    
    private void OnGUI()
    {
        if (scenaAsyncOperation != null && loadingBar != null)
        {
            float progress = scenaAsyncOperation.progress;
            loadingBar.value = progress;
        }
    }

    public void Play()
    {
        scenaAsyncOperation = SceneManager.LoadSceneAsync(index);
    }
}
