using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameTimer))]
public class GameTimerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            EditorGUILayout.LabelField("Current Time: " + GameTimer.time);
            EditorGUILayout.LabelField(GameTimer.isPaused ? "Paused" : "Not Paused");
            if (!GameTimer.isPaused)
            {
                EditorUtility.SetDirty(target);
            }
            if (GUILayout.Button(GameTimer.isPaused ? "Unpause Timer" : "Pause Timer"))
            {
                if (!GameTimer.isPaused)
                    GameTimer.PauseTimer();
                else
                    GameTimer.UnpauseTimer();
            }
        }
    }
}
