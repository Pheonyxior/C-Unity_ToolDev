using UnityEditor;
using UnityEngine;

public static class PrefabUtilityTesting
{
    [MenuItem("Prefabs/Test_EditPrefabContentsScope")]
    public static void Test()
    {
        // Create a simple test Prefab Asset. Looks like this:
        // Root
        //    A
        //    B
        //    C
        var assetPath = "Assets/MyTempPrefab.prefab";
        var source = new GameObject("Root");
        var childA = new GameObject("A");
        var childB = new GameObject("B");
        var childC = new GameObject("C");
        childA.transform.parent = source.transform;
        childB.transform.parent = source.transform;
        childC.transform.parent = source.transform;
        PrefabUtility.SaveAsPrefabAsset(source, assetPath);

        using (var editingScope = new PrefabUtility.EditPrefabContentsScope(assetPath))
        {
            var prefabRoot = editingScope.prefabContentsRoot;

            // Removing GameObjects is supported
            Object.DestroyImmediate(prefabRoot.transform.GetChild(2).gameObject);

            // Reordering and reparenting are supported
            prefabRoot.transform.GetChild(1).parent = prefabRoot.transform.GetChild(0);

            // Adding GameObjects is supported
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = prefabRoot.transform;
            cube.name = "D";

            // Adding and removing components are supported
            prefabRoot.AddComponent<AudioSource>();
        }

        // Prefab Asset now looks like this:
        // Root
        //    A
        //       B
        //    D
    }
}