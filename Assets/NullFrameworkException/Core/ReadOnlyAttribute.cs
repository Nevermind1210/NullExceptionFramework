using UnityEditor;
using UnityEngine;

namespace NullFrameworkException.Core
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyAttribute : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            // Disable the GUI, making this readonly, as it still renders, just becomes not -interactabl
            EditorGUI.BeginProperty(_position, _label, _property);
            {
                GUI.enabled = false;
                {
                    // Render the property exactly as it already is
                    EditorGUI.PropertyField(_position, _property, _label);
                }
                // re-enable the GUI to make everything work after this property
                GUI.enabled = true;
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label) =>
            EditorGUI.GetPropertyHeight(_property);
    }
}