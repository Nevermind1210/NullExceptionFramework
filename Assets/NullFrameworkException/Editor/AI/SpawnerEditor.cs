using System;
using UnityEngine;
using NullFrameworkException.Test.AI;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditor.IMGUI.Controls;

namespace NullFrameworkException.Editor.AI
{
    [UnityEditor.CustomEditor(typeof(Spawner))]
    public class SpawnerEditor : UnityEditor.Editor
    {
        // The reference to the component we are drawing the editor for
        private Spawner spawner;

        // The references to the values of the variables in held in the script
        private SerializedProperty sizeProperty;
        private SerializedProperty centerProperty;

        private SerializedProperty floorYPositionProperty;
        private SerializedProperty spawnRateProperty;

        private SerializedProperty shouldSpawnBossProperty;
        private SerializedProperty bossSpawnChanceProperty;
        private SerializedProperty enemyPrefabProperty;
        private SerializedProperty bossPrefabProperty;
        //The custom animation and scene elements
        private AnimBool shouldSpawnBoss = new AnimBool();
        private BoxBoundsHandle handle;
        
        private void OnEnable()
        {
            spawner = target as Spawner;
            
            // Retrieve the serializedProperties from object
            sizeProperty = serializedObject.FindProperty("size");
            centerProperty = serializedObject.FindProperty("center");
            
            floorYPositionProperty = serializedObject.FindProperty("floorYPosition");
            spawnRateProperty = serializedObject.FindProperty("spawnRate");
            
            shouldSpawnBossProperty = serializedObject.FindProperty("shouldSpawnBoss");
            bossSpawnChanceProperty = serializedObject.FindProperty("bossSpawnChance");
            bossPrefabProperty = serializedObject.FindProperty("bossPrefab");
            enemyPrefabProperty = serializedObject.FindProperty("enemyPrefab");

        }

        private void OnSceneGUI()
        {
            // Set the handles colour to green and store the original and store the original matrix value
            Handles.color = Color.green;
            Matrix4x4 original = Handles.matrix;
            
            // Changes the handles Matrix to be using the transform of this object 
            Handles.matrix = spawner.transform.localToWorldMatrix;
            
            // Setup the box bounds handle with the spawner values
            handle.center = spawner.center;
            handle.size = spawner.size;
            
            // Begin listening fpr changes to the handle and draw it
            EditorGUI.BeginChangeCheck();
            handle.DrawHandle();
            
            //Check if any changes were made
            if (EditorGUI.EndChangeCheck())
            {
                spawner.size = handle.size;
                spawner.center = handle.center;
                
                // Register this change for Undo-redo system
                Undo.RecordObject(spawner, "UPDATE_SPAWNER_BOUNDS");
            }
            
            // Reset the handles matrix 
            Handles.matrix = original;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                {
                    // Draw the center and size properties exactly as unity would
                    EditorGUILayout.PropertyField(centerProperty);
                    EditorGUILayout.PropertyField(sizeProperty);
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(GUI.skin.box);
                {
                    EditorGUILayout.PropertyField(floorYPositionProperty);
                    
                    // Cache the original value of the spawn rate and create a label
                    Vector2 spawnRate = spawnRateProperty.vector2Value;
                    string label = $"Range ({spawnRate.x:0.0}s - {spawnRate.y:0.0}s";
                    
                    EditorGUILayout.MinMaxSlider(label, ref spawnRate.x, ref spawnRate.y, 0, 3);
                    spawnRateProperty.vector2Value = spawnRate;
                    
                    // Apply some space between lines
                    EditorGUILayout.Space();
                    
                    // Render the enemyPrefab and shouldSpawnBoss as normal
                    EditorGUILayout.PropertyField(enemyPrefabProperty);
                    EditorGUILayout.PropertyField(shouldSpawnBossProperty);
                    
                    // Attempt to fade the next variables in and out
                    shouldSpawnBoss.target = shouldSpawnBossProperty.boolValue;
                    if (EditorGUILayout.BeginFadeGroup(shouldSpawnBoss.faded))
                    {
                        // Only visible when 'shouldSpawnBoss' in Spawner script is true
                        
                        //Indent the editor
                        EditorGUI.indentLevel++;
                        {
                            // Draw your mom
                            // Draw bossSpawnChance and bossPrefab as normal
                            EditorGUILayout.PropertyField(bossSpawnChanceProperty);
                            EditorGUILayout.PropertyField(bossPrefabProperty);
                        }
                        EditorGUI.indentLevel--;
                    }
                    EditorGUILayout.EndFadeGroup();
                }
                EditorGUILayout.EndVertical();
                // Apply the changes we made in the inspector
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}