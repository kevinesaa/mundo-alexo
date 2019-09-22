using UnityEngine;

[System.Serializable]
public class SceneInBuildConfigContainer 
{
    [SerializeField]
    private readonly string sceneName;
    [SerializeField]
    private readonly int sceneIndex;

    public SceneInBuildConfigContainer(string sceneName, int sceneIndex)
    {
        this.sceneName = sceneName;
        this.sceneIndex = sceneIndex;
        
    }

    public string SceneName { get { return sceneName; } }
    public int SceneIndex { get { return sceneIndex; } }
}
