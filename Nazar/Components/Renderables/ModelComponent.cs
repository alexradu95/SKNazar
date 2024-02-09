namespace Nazar.Components;

public struct ModelComponent
{
    public Model Model;
    public Vec3 Offset;

    public void Draw(TransformComponent transform)
    {
        Model.Draw(Matrix.TRS(transform.Position.position + Offset, transform.Rotation, transform.Scale));
    }
}
