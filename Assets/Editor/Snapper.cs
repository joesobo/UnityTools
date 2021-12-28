using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Snapper : EditorWindow {
    private float snapValue = 1;
    private float radiusSize = 1;
    private float angleSize = 0;
    private bool usePolarCoords = false;

    [MenuItem("Tools/Snapper")]
    public static void WindowSnapper() => GetWindow<Snapper>();

    private void OnGUI() {
        GUILayout.Label("Snapper", EditorStyles.boldLabel);
        GUILayout.Space(20);

        usePolarCoords = GUILayout.Toggle(usePolarCoords, "Use Polar Coordinates");

        GUILayout.Space(20);
        if (usePolarCoords) {
            radiusSize = EditorGUILayout.FloatField("Radius Size: ", radiusSize);
            angleSize = EditorGUILayout.FloatField("Angle Size: ", angleSize);
        } else {
            snapValue = EditorGUILayout.FloatField("Snap to: ", snapValue);
        }

        if (GUILayout.Button("Snap Selection")) {
            Snap();
        }
    }

    private void Snap() {
        foreach (GameObject go in Selection.gameObjects) {
            Undo.RecordObject(go.transform, "Snap");

            if (usePolarCoords) {
                go.transform.position = go.transform.position.RoundToPolarCoords(radiusSize, angleSize);
            } else {
                go.transform.position = go.transform.position.RoundToNearest(snapValue);
            }
        }
    }
}
