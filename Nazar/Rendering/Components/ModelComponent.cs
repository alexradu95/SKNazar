using Nazar.Components;

namespace Nazar.Rendering.Components;

public struct ModelComponent
{
    public Model Model;

    public void Draw(TransformComponent transform)
    {
        Model.Draw(transform.ToMatrix());
    }
}
