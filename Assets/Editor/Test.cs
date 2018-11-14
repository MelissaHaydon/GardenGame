using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test : EditorWindow {

    GameObject testerPar;

    [MenuItem("Window/Test Window")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Test>("Test This");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("This thing"))
        {

        }
    }
}
