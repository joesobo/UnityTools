using UnityEngine;

public static class VectorLogic {
    public static Vector3 Round(this Vector3 v) {
        v.x = Mathf.Round(v.x);
        v.y = Mathf.Round(v.y);
        v.z = Mathf.Round(v.z);
        return v;
    }
}
