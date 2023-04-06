using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class UIT_BuildingEditor : EditorWindow
{
    [MenuItem("Window/UI Toolkit/UIT_BuildingEditor")]
    public static void ShowExample()
    {
        UIT_BuildingEditor wnd = GetWindow<UIT_BuildingEditor>();
        wnd.titleContent = new GUIContent("Drag And Drop");
    }

    public void CreateGUI()
    {
        DragAndDropManipulator manipulator =
        new(rootVisualElement.Q<VisualElement>("object"));

        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

          // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Drag and Drop/DragAndDropWindow.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Drag and Drop/DragAndDropWindow.uss");
    
    }
}