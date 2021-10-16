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

            Cube cube = (Cube)target; // This initalizes the script and casts the script to be target and target is a base unity thing but we override that and give it only power for that particular script.
            
            // This whole Begin and End Horizontal is more for more control on how the layout looks inside the unity inspector and give you more choices
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