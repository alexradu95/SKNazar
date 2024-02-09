using Nazar.Components;

namespace Nazar.Systems.Renderers;

public class MeshRenderSystem : BaseSystem<float>
{
    public MeshRenderSystem(World world) : base(world)
    {
    }

    public override void Update(float state)
    {
        var meshComponents = World.GetComponents<MeshComponent>().AsEnumerable();
        foreach (MeshComponent meshComponent in meshComponents)
        {
            meshComponent.Draw();
        }
    }
}
