using UnityEngine;

public static class FloatExtension {
    public static float Min(this float value, float min) {
        if (value < min) {
            value = min;
        }
        return value;
    }

    public static float Max(this float value, float max) {
        if (value > max) {
            value = max;
        }
        return value;
    }

    public static float Round(this float value) {
        return Mathf.Round(value);
    }

    public static float RoundToNearest(this float value, float nearest) {
        return Round(value / nearest) * nearest;
    }
}
