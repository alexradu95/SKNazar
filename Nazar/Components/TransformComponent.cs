namespace Nazar.Components;

public struct TransformComponent
{
    public Pose Position;
    public Vec3 Scale;
    public Quat Rotation;

    public TransformComponent(Pose position, Vec3 scale, Quat rotation)
    {
        Position = position;
        Scale = scale;
        Rotation = rotation;
    }

    public Matrix ToMatrix()
    {
        return Matrix.TRS(Position.position, Rotation, Scale);
    }
}
