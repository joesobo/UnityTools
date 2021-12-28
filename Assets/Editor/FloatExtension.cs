using UnityEngine;

public static class FloatExtension {
    public static float Min(this float value, float min) {
        if (value < min) {
            value = min;
        }
        return value;
    }
}
