using Nazar.Components.Renderables;
using Nazar.Foundation;

namespace Nazar.Systems.Renderers;

public class MeshRenderSystem : BaseSystem<float>
{
    public MeshRenderSystem(World world) : base(world)
    {
    }

    public override void Update(float state)
    {
        var meshComponents = World.GetComponents<MeshComponent>();
        foreach (var meshComponent in meshComponents)
        {
            meshComponent.Draw();
        }
    }
}
using Nazar.Components.Renderables;
using Nazar.Foundation;

namespace Nazar.Systems.Renderers;

public class MeshRenderSystem : BaseSystem<float>
{
    public MeshRenderSystem(World world) : base(world)
    {
    }

    public override void Update(float state)
    {
        var meshComponents = World.GetComponents<MeshComponent>();
        foreach (var meshComponent in meshComponents)
        {
            meshComponent.Draw();
        }
    }
}
