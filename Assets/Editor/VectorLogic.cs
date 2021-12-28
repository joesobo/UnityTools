using UnityEngine;

public static class VectorLogic {
    public static Vector3 Round(this Vector3 v) {
        v.x = Mathf.Round(v.x);
        v.y = Mathf.Round(v.y);
        v.z = Mathf.Round(v.z);
        return v;
    }

    public static Vector3 RoundToNearest(this Vector3 v, float nearest) {
        v.x = RoundTo(v.x, nearest);
        v.y = RoundTo(v.y, nearest);
        v.z = RoundTo(v.z, nearest);
        return v;
    }

    public static Vector3 RoundToPolarCoords(this Vector3 v, float radius, float angle) {
        float newX = radius * Mathf.Cos(angle);
        float newZ = radius * Mathf.Sin(angle);

        return new Vector3(newX, 0, newZ);
    }

    public static float RoundTo(float value, float multipleOf) {
        return Mathf.Round(value / multipleOf) * multipleOf;
    }

}
