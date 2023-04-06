using UnityEngine;
using UnityEditor;


public class Alduin : EditorWindow 
{
    
    bool toggled0;
    bool toggled1;
    string str;
    //string selectedGameObjectName;

    [MenuItem("/ProtoGridBuilding/Alduin")]
    private static void ShowWindow() 
    {
        var window = GetWindow<Alduin>();
        window.titleContent = new GUIContent("Alduin");
        window.Show();
    }

    private void OnGUI() 
    {
        

        toggled0 = EditorGUILayout.BeginToggleGroup("ObjectTransforms", toggled0);

        if(toggled0)
        {
            for(int i = 0; i < Selection.gameObjects.Length; i++) 
            {
                EditorGUILayout.BeginHorizontal();

                GameObject selectedGameObject = Selection.gameObjects[i];
                str = EditorGUILayout.TextField(str);
                EditorGUILayout.Space();

                EditorGUILayout.BeginVertical();
                EditorGUILayout.Vector3Field("Position: ", selectedGameObject.transform.position);
                
                EditorGUILayout.Vector3Field("Rotation: ", selectedGameObject.transform.rotation.eulerAngles);
                
                EditorGUILayout.Vector3Field("Scale: ", selectedGameObject.transform.localScale);
                
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                EditorGUILayout.Space();

                }
            
        }
        EditorGUILayout.EndToggleGroup();


        //toggled1 = EditorGUILayout.BeginToggleGroup("ObjectTransforms", toggled1);

     

             
          
    }

    
}


