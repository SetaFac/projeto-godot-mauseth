using Godot;

namespace nostart_framework_godot.SuperVector;

public static class Direction
{
    public static int PointDirection(Vector2 from, Vector2 to)
    {
        Vector2 newDir = from - to;
        newDir.X *= -1;
        newDir.Y *= -1;

        return (int)Mathf.PosMod(Mathf.RadToDeg(newDir.Angle()), 360);
    }

    public static Vector2 LengthDir(int length, int direction)
    {
        float angleRad = Mathf.DegToRad(direction);
        return new Vector2(
            length * Mathf.Cos(angleRad),
            length * Mathf.Sin(angleRad)
        );
    }
}   