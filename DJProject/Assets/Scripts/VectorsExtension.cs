using UnityEngine;

public static class VectorExtension
{
    public static Vector3 WithAxis(this Vector3 vector, Axis axis, float x)
    {
        return new Vector3(
            axis == Axis.X ? x : vector.x,
            axis == Axis.Y ? x : vector.y,
            axis == Axis.Z ? x : vector.z
        );
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}
