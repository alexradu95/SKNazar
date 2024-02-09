namespace Nazar.Components;

public struct TransformComponent
{
    public Pose Position;

    public readonly Matrix ToMatrix()
    {
        return Matrix.TRS(Position.position, Vec3.One, Vec3.One);
    }
}
