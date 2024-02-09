using Nazar.Components;

namespace Nazar.Systems.Renderers;

public class MeshRenderSystem(World world) : BaseSystem<float>(world)
{
    public override void Update(float state)
    {
        var meshEntities = World.GetEntities().With<MeshComponent>().With<TransformComponent>().AsSet();
        foreach (ref readonly var entity in meshEntities.GetEntities())
        {
            ref var meshComponent = ref entity.Get<MeshComponent>();
            ref var transformComponent = ref entity.Get<TransformComponent>();
            meshComponent.Mesh.Draw(Material.Default, transformComponent.ToMatrix());
        }
    }
}
