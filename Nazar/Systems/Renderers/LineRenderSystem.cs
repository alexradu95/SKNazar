using Nazar.Components;
using StereoKit;

namespace Nazar.Systems.Renderers;

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