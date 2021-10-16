using UnityEngine;
using UnityEditor;

namespace NullFrameworkException.Editor.CustomEditor
{
    [UnityEditor.CustomEditor(typeof(Cube))]
    public class CoolInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Cube cube = (Cube)target;
            
            GUILayout.BeginHorizontal();
            
                if (GUILayout.Button("Change Color!"))
                {
                  cube.GenerateColor();
                }
                
                if (GUILayout.Button("Reset Color"))
                {
                    cube.Reset();
                }
                
            GUILayout.EndHorizontal();
        }
    }
}