using Nazar.Components;
using StereoKit;

namespace Nazar.Systems;

public class RenderSystem : BaseSystem<float>
{
    public RenderSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var renderableEntities = World.GetEntities()
            .With<MeshComponent>()
            .With<MaterialComponent>()
            .With<TransformComponent>()
            .AsSet();

        foreach (ref readonly var entity in renderableEntities.GetEntities())
        {
            ref var mesh = ref entity.Get<MeshComponent>().Mesh;
            ref var material = ref entity.Get<MaterialComponent>().Material;
            ref var transform = ref entity.Get<TransformComponent>().Transform;

            mesh.Draw(material, transform);
        }
    }
}
