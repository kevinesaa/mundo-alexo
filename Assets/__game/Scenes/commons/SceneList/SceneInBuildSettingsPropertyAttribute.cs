using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneInBuildSettingsPropertyAttribute : PropertyAttribute
{
    public delegate SceneInBuildConfigContainer[] GetStringList();
   
    public SceneInBuildConfigContainer[] SceneList{ get; private set;}
    public string[] names;

    public SceneInBuildSettingsPropertyAttribute(Type type, string methodName)
    {
        var method = type.GetMethod(methodName);
        if (method != null)
        {
            SceneList = method.Invoke(null, null) as SceneInBuildConfigContainer[];
            names = new string[SceneList.Length];
            for (int i=0; i<SceneList.Length;i++ )
            {
                names[i] = "index: " + SceneList[i].SceneIndex + " - name: " + SceneList[i].SceneName;
            }
        }
        else
        {
            Debug.LogError("NO SUCH METHOD " + methodName + " FOR " + type);
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneInBuildSettingsPropertyAttribute))]
    public class StringInListDrawer : PropertyDrawer
    {
        
        private int selectedIndex = 0;

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var scenesInBuildSetting = attribute as SceneInBuildSettingsPropertyAttribute;
            var listScene = scenesInBuildSetting.SceneList;
            selectedIndex = EditorGUI.Popup(position,property.displayName , selectedIndex, scenesInBuildSetting.names);
            
        }
    }
#endif
}
