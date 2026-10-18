using UnityEditor;
using UnityEngine;
using FoxTools.VariableObjects;

[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : PropertyDrawer
{
    private const float ToggleWidth = 18f;
    private const float Spacing = 4f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty useConstantProp = property.FindPropertyRelative("UseConstant");
        SerializedProperty constantValueProp = property.FindPropertyRelative("ConstantValue");
        SerializedProperty variableProp = property.FindPropertyRelative("Variable");

        position = EditorGUI.PrefixLabel(position, label);

        int oldIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect toggleRect = new Rect(position.x, position.y, ToggleWidth, position.height);
        Rect fieldRect = new Rect(
            position.x + ToggleWidth + Spacing,
            position.y,
            position.width - ToggleWidth - Spacing,
            position.height
        );

        useConstantProp.boolValue = EditorGUI.Toggle(toggleRect, useConstantProp.boolValue);

        if (useConstantProp.boolValue)
        {
            EditorGUI.PropertyField(fieldRect, constantValueProp, GUIContent.none);
        }
        else
        {
            EditorGUI.PropertyField(fieldRect, variableProp, GUIContent.none);
        }

        EditorGUI.indentLevel = oldIndent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}