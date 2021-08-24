﻿using NullFrameworkException.Core;
using UnityEditor;
using UnityEngine;

namespace NullFrameworkException.Editor.Core
{
    [CustomPropertyDrawer(typeof(SceneFieldDrawer))]
    public class SceneFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            EditorGUI.BeginProperty(_position, _label, _property);
            {
                SceneAsset oldScene =
                    AssetDatabase.LoadAssetAtPath<SceneAsset>(SceneFieldAttribute.ToAssetPath(_property.stringValue));

                // Check if anything has changed in the inspector
                EditorGUI.BeginChangeCheck();

                // Draw the scene field as an object field with the SceneAsset type
                SceneAsset newScene =
                    EditorGUI.ObjectField(_position, _label, oldScene, typeof(SceneAsset), false) as SceneAsset;

                if (EditorGUI.EndChangeCheck())
                {
                    // Set the string value to the path of the new scene
                    string path = SceneFieldAttribute.LoadableName(AssetDatabase.GetAssetPath(newScene));
                    _property.stringValue = path;
                }
            }
            EditorGUI.EndProperty();
        }
        
        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label) => EditorGUIUtility.singleLineHeight;
    }
}