using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public static class SceneInBuildSettingListHelper 
{
#if UNITY_EDITOR
    public static SceneInBuildConfigContainer[] AllScene()
    {
        var temp = new List<SceneInBuildConfigContainer>();
        
        foreach (UnityEditor.EditorBuildSettingsScene scene in UnityEditor.EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                int index = SceneUtility.GetBuildIndexByScenePath(scene.path);
                string name = Path.GetFileNameWithoutExtension(scene.path);
                SceneInBuildConfigContainer item = new SceneInBuildConfigContainer(name, index);
                temp.Add(item);
            }
        }
        return temp.ToArray();
    }
#endif
}
