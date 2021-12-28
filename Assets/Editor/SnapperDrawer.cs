using static MathExtension;
using UnityEditor;
using UnityEngine;

public static class SnapperDrawer {
    private static float gridDrawExtent = 16;

    public static void DrawPolarGrid(float radiusSize, int angleDivision) {
        int ringCount = Mathf.RoundToInt(gridDrawExtent / radiusSize);
        float radiusOuter = (ringCount - 1) * radiusSize;

        for (int i = 1; i < ringCount; i++) {
            Handles.DrawWireDisc(Vector3.zero, Vector3.up, i * radiusSize);
        }

        for (int i = 0; i < angleDivision; i++) {
            float t = i / (float)angleDivision;
            float angRad = t * TAU; // percentage to radians

            Handles.DrawAAPolyLine(Vector3.zero, new Vector3(Mathf.Cos(angRad), 0, Mathf.Sin(angRad)) * radiusOuter);
        }
    }

    public static void DrawCartesianGrid(float snapValue) {
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
