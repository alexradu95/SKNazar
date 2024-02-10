using StereoKit;

namespace Nazar.Components;

public struct TransformComponent
{
    public Pose Position;
    public Vec3 Scale;

    public Matrix ToMatrix()
    {
        return Matrix.TRS(Position.position, Position.orientation, Scale);
    }
}
