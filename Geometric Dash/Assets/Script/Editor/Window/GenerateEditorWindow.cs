using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [CustomEditor(typeof(GenerateObjects))]

public class GenerateEditorWindow : EditorWindow
{

    [MenuItem("Window/Generate Object Editor")]
    
    static void OpenWindow()
    {
        GenerateEditorWindow _window = (GenerateEditorWindow)GetWindow(typeof(GenerateEditorWindow));
        _window.minSize = new Vector2(600,300);
        _window.Show();
        
    }



    // public override void OnInspectorGUI()
    // {
    //     DrawDefaultInspector();

    //     GenerateObjects _obj = (GenerateObjects)target;
        

    //     if(GUILayout.Button("Generate Object"))
    //     {
    //         _obj.GenerateObject();
    //     }
        
    // }
    
}
