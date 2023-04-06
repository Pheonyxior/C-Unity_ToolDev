using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

public class BuildingEditor : EditorWindow 
{
    Texture buttonTex;

    string buildingName;

    List<Object> TileObjects = new List<Object>();
    List<Vector2Int> TilePositions = new List<Vector2Int>();
   
    


    //List<TileBuildingGUI> tilesGUI = new List< TileBuildingGUI>();
    //SerializedObject tileSprite = new SerializedObject(tileBuildingGUI);
    

    [MenuItem("ProtoGridBuilding/BuildingEditor")]
    private static void ShowWindow() 
    {
        var window = GetWindow<BuildingEditor>();
        window.titleContent = new GUIContent("BuildingEditor");
        window.Show();
        
    }

    private void OnGUI() 
    {
        buildingName = EditorGUILayout.TextField(buildingName);

        AddTileButton();

        for(int i = 0; i < TileObjects.Count; i++) 
        {
            

            EditorGUILayout.BeginHorizontal();


            TileObjects[i] = EditorGUILayout.ObjectField(TileObjects[i], typeof(Sprite), false);
           

            GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), AssetPreview.GetAssetPreview(TileObjects[i]));

            TilePositions[i] = EditorGUILayout.Vector2IntField("TilePosition", TilePositions[i]);


            EditorGUILayout.EndHorizontal();

            BigSpace();
        }

        GenerateBuildingPrefabButton();

        ClearTilesButton();
        

    }

    private void AddTileButton () 
    {
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Add Tile"))
        {
            TileObjects.Add(new Object());
            TilePositions.Add(new Vector2Int());
        }

        EditorGUILayout.EndVertical();
    }

    private void ClearTilesButton () 
    {
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Clear Tiles"))
        {
            TileObjects.Clear();
            TilePositions.Clear();

        }

        EditorGUILayout.EndVertical();
    }

    private void GenerateBuildingPrefabButton()
    {
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("GenerateBuildingPrefab"))
        {
            GenerateBuildingPrefab();
        }

        EditorGUILayout.EndVertical();
    }

    private void GenerateBuildingPrefab () 
    {
        string assetPath = $"Assets/01_Buildings/BuildingPrefabs/{buildingName}VisualPrefab.prefab";

        GameObject root = new GameObject($"{buildingName}Visual");
        for(int i = 0; i < TileObjects.Count; i++)
        {
            GameObject tileChild = new GameObject("tile");
            
            SpriteRenderer spriteRenderer = tileChild.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = (Sprite)TileObjects[i];

            tileChild.transform.parent = root.transform;
            tileChild.transform.position = (Vector2)TilePositions[i];
            tileChild.transform.localScale = Vector3.one * 6.25f;
        }

        PrefabUtility.SaveAsPrefabAsset(root, assetPath);

    }



    private void DisplayTile(Object tile, Vector2Int tilePos)
    {
        EditorGUILayout.BeginHorizontal();
        tile = EditorGUILayout.ObjectField(tile, typeof(Sprite), false);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), AssetPreview.GetAssetPreview(tile));
        tilePos = EditorGUILayout.Vector2IntField("TilePosition", tilePos);
        EditorGUILayout.EndHorizontal();
    }

    private void BigSpace()
    {
        EditorGUILayout.Space(10);
    }

    
}