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
            .WithAny<ModelComponent, LineComponent, TextComponent>()
            .AsSet();

        foreach (ref readonly var entity in renderableEntities.GetEntities())
        {
            ref var mesh = ref entity.Get<MeshComponent>().Mesh;
            ref var material = ref entity.Get<MaterialComponent>().Material;
            ref var transform = ref entity.Get<TransformComponent>();

            mesh.Draw(material, transform.ToMatrix());
        }

        if (entity.Has<ModelComponent>())
        {
            ref var modelComponent = ref entity.Get<ModelComponent>();
            modelComponent.Draw(transform);
        }

        if (entity.Has<LineComponent>())
        {
            ref var lineComponent = ref entity.Get<LineComponent>();
            lineComponent.Draw();
        }

        if (entity.Has<TextComponent>())
        {
            ref var textComponent = ref entity.Get<TextComponent>();
            textComponent.Draw();
        }
    }
}
