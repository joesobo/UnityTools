using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Snapper : EditorWindow {
    private float snapValue = 1;
    private float radiusSize = 1;
    private int angleDivision = 24;
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

        if (Event.current.type == EventType.Repaint) {
            if (usePolarCoords) {
                SnapperDrawer.DrawPolarGrid(radiusSize, angleDivision);
            } else {
                SnapperDrawer.DrawCartesianGrid(snapValue);
            }
        }
    }

    private void OnGUI() {
        GUILayout.Label("Snapper", EditorStyles.boldLabel);
        GUILayout.Space(20);

        usePolarCoords = GUILayout.Toggle(usePolarCoords, "Use Polar Coordinates");

        GUILayout.Space(20);
        if (usePolarCoords) {
            radiusSize = EditorGUILayout.FloatField("Radius Size: ", radiusSize).Min(0.1f);
            angleDivision = EditorGUILayout.IntField("Angle Division: ", angleDivision).Min(2);
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
                go.transform.position = go.transform.position.RoundToPolarCoords(radiusSize, angleDivision);
            } else {
                go.transform.position = go.transform.position.RoundToNearest(snapValue);
            }
        }
    }
}
