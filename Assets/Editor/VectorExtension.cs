using UnityEngine;
using static MathExtension;

public static class VectorExtension {
    public static Vector3 Round(this Vector3 v) {
        v.x = Mathf.Round(v.x);
        v.y = Mathf.Round(v.y);
        v.z = Mathf.Round(v.z);
        return v;
    }

    public static Vector3 RoundToNearest(this Vector3 v, float nearest) {
        return Round(v / nearest) * nearest;
    }

    public static Vector3 RoundToPolarCoords(this Vector3 v, float radiusSize, int angleDivision) {
        Vector2 vec = new Vector2(v.x, v.z);
        float dist = vec.magnitude;
        float distSnapped = dist.RoundToNearest(radiusSize);

        float angRad = Mathf.Atan2(v.z, v.x);
        float angTurns = angRad / TAU; // percentage to radians
        float angTurnsSnapped = angTurns.RoundToNearest(1f / angleDivision);
        float angRadSnapped = angTurnsSnapped * TAU;

        return new Vector3(Mathf.Cos(angRadSnapped), 0, Mathf.Sin(angRadSnapped)) * distSnapped;
    }
}
