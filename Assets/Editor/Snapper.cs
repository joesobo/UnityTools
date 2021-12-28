using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Snapper : EditorWindow {
    [MenuItem("Tools/Snapper")]
    public static void WindowSnapper() => GetWindow<Snapper>();

    private void OnGUI() {
        GUILayout.Label("Snapper", EditorStyles.boldLabel);

        if (GUILayout.Button("Snap Selection")) {
            Snap();
        }
    }

    private void Snap() {
        foreach (GameObject go in Selection.gameObjects) {
            Undo.RecordObject(go.transform, "Snap");
            go.transform.position = go.transform.position.Round();
        }
    }
}
