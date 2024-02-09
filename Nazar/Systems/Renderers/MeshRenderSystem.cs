using Nazar.Components;

namespace Nazar.Systems.Renderers;

public class MeshRenderSystem : BaseSystem<float>
{
    public MeshRenderSystem(World world) : base(world)
    {
    }

    public override void Update(float state)
    {
        var meshEntities = World.GetEntities().With<MeshComponent>().AsSet();
        foreach (ref readonly var entity in meshEntities.GetEntities())
        {
            ref var meshComponent = ref entity.Get<MeshComponent>();
            // Assuming there is a Draw method in MeshComponent that takes no arguments
            meshComponent.Draw();
        }
    }
}
