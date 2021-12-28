using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Snapper : EditorWindow {
    private float snapValue = 1;
    private float radiusSize = 1;
    private float angleSize = 0;
    private float gridDrawExtent = 16;
    private bool usePolarCoords = false;

    [MenuItem("Tools/Snapper")]
    public static void WindowSnapper() => GetWindow<Snapper>();

    private void OnEnable() {
        Selection.selectionChanged += Repaint;
        SceneView.duringSceneGui += DuringSceneGUI;
    }

    private void OnDisable() {
        Selection.selectionChanged -= Repaint;
        SceneView.duringSceneGui -= DuringSceneGUI;
    }

    private void DuringSceneGUI(SceneView sceneView) {
        Handles.color = new Color(1, 1, 1, 0.75f);
        Handles.zTest = CompareFunction.LessEqual;

        if (usePolarCoords) {
            DrawPolarGrid();
        } else {
            DrawCartesianGrid();
        }
    }

    private void OnGUI() {
        GUILayout.Label("Snapper", EditorStyles.boldLabel);
        GUILayout.Space(20);

        usePolarCoords = GUILayout.Toggle(usePolarCoords, "Use Polar Coordinates");

        GUILayout.Space(20);
        if (usePolarCoords) {
            radiusSize = EditorGUILayout.FloatField("Radius Size: ", radiusSize).Min(1);
            angleSize = EditorGUILayout.FloatField("Angle Size: ", angleSize).Min(0);
        } else {
            snapValue = EditorGUILayout.FloatField("Snap to: ", snapValue).Min(0.1f);
        }

        using (new EditorGUI.DisabledScope(Selection.gameObjects.Length == 0)) {
            if (GUILayout.Button("Snap Selection")) {
                Snap();
            }
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

    private void DrawPolarGrid() {
        for (int i = 0; i < gridDrawExtent * 2; i++) {
            Handles.DrawWireDisc(Vector3.zero, new Vector3(0, 1, 0), i);
        }
    }

    private void DrawCartesianGrid() {
        int lineCount = Mathf.RoundToInt((gridDrawExtent * 2) / snapValue);
        if (lineCount % 2 == 0) lineCount++;
        int halfLineCount = lineCount / 2;

        for (int i = 0; i < lineCount; i++) {
            int intOffset = i - halfLineCount;

            float xCoord = intOffset * snapValue;
            float zCoord0 = halfLineCount * snapValue;
            float zCoord1 = -halfLineCount * snapValue;

            Handles.DrawAAPolyLine(new Vector3(xCoord, 0, zCoord0), new Vector3(xCoord, 0, zCoord1));

            Handles.DrawAAPolyLine(new Vector3(zCoord0, 0, xCoord), new Vector3(zCoord1, 0, xCoord));
        }
    }
}
