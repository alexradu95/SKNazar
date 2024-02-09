using Nazar.Rendering.Components;

namespace Nazar.Rendering.Systems;

public class LineRenderSystem : BaseSystem<float>
{
    public LineRenderSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var lineEntities = World.GetEntities()
            .With<LineComponent>()
            .AsSet();

        foreach (ref readonly var entity in lineEntities.GetEntities())
        {
            ref var lineComponent = ref entity.Get<LineComponent>();
            lineComponent.Draw();
        }
    }
}
