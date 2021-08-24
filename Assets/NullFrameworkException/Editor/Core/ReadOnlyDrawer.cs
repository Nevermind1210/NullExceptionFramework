using UnityEditor;
using UnityEngine;

namespace NullFrameworkException.Editor.Core
{
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            EditorGUI.BeginProperty(_position, _label, _property);
            {
                // Disable the GUI, making this readonly, as it still renders, 
                GUI.enabled = false;
                {
                    EditorGUI.PropertyField(_position, _property, _label);
                }
                GUI.enabled = true;
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label) =>
            EditorGUI.GetPropertyHeight(_property);
    }
}