using UnityEngine;

public static class VectorLogic {
    public static Vector3 Round(this Vector3 v) {
        v.x = Mathf.Round(v.x);
        v.y = Mathf.Round(v.y);
        v.z = Mathf.Round(v.z);
        return v;
    }

    public static Vector3 RoundToNearest(this Vector3 v, int nearest) {
        v.x = RoundTo(v.x, nearest);
        v.y = RoundTo(v.y, nearest);
        v.z = RoundTo(v.z, nearest);
        return v;
    }

    public static float RoundTo(float value, float multipleOf) {
        return Mathf.Round(value / multipleOf) * multipleOf;
    }
}
