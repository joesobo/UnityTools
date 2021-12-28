using UnityEngine;

public static class IntExtension {
    public static int Min(this int value, int min) {
        if (value < min) {
            value = min;
        }
        return value;
    }

    public static int Max(this int value, int max) {
        if (value > max) {
            value = max;
        }
        return value;
    }
}
