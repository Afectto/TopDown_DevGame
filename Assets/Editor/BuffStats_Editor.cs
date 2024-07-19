using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BuffStats))]
public class BuffStats_Editor : Editor
{
    private SerializedProperty _type;
    private SerializedProperty _value;
    private SerializedProperty _duration;
    private SerializedProperty _skin;
    private void OnEnable()
    {
        _type = serializedObject.FindProperty("type");
        _duration = serializedObject.FindProperty("duration");
        _skin = serializedObject.FindProperty("skin");
    }
    
    public override void OnInspectorGUI()
    {
        var controller = (BuffStats) target;
        
        serializedObject.Update();
        EditorGUILayout.PropertyField(_type);
        
        switch (controller.Type)
        {
            case BuffType.Speed:
                _value = serializedObject.FindProperty("value");
                EditorGUILayout.PropertyField(_value);
                break;
        }
        
        EditorGUILayout.PropertyField(_duration);
        EditorGUILayout.PropertyField(_skin);
        
        serializedObject.ApplyModifiedProperties();
    }
}
