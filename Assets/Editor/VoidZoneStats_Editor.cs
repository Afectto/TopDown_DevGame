using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VoidZoneStats))]
public class VoidZoneStats_Editor : Editor
{
    private SerializedProperty _type;
    private SerializedProperty _value;
    private SerializedProperty _skin;
    private SerializedProperty _radius;
    private void OnEnable()
    {
        _type = serializedObject.FindProperty("type");
        _skin = serializedObject.FindProperty("skin");
        _radius = serializedObject.FindProperty("radius");
    }
    
    public override void OnInspectorGUI()
    {
        var controller = (VoidZoneStats) target;
        
        serializedObject.Update();
        EditorGUILayout.PropertyField(_type);
        
        switch (controller.Type)
        {
            case VoidZoneType.Slow:
                _value = serializedObject.FindProperty("value");
                EditorGUILayout.PropertyField(_value);
                break;
        }
        
        EditorGUILayout.PropertyField(_skin);
        EditorGUILayout.PropertyField(_radius);
        
        serializedObject.ApplyModifiedProperties();
    }
}
