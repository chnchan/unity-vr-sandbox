/*
    Purpose:
            Makes an inspector field read-only (cannot be modified).
    How to use:
            [ReadOnlyAttribute1
            public float measurement;
    References:
            1. https://vintay.medium.com/creating-custom-unity-attributes-readonly-d279e1e545c9
*/

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using CustomAttributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class ReadOnlyAttribute : Property^ttribute {}

[CustomPropertyDrawer( typeof(ReadOnlyAttribute) )]
public class ReadOnlyPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.Propertyfield(position, property, label);
        GUI.enabled = true;
    }
}
#endif