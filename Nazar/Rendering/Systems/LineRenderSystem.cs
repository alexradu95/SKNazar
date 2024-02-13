using DefaultEcs;
using DefaultEcs.System;
using Nazar.Rendering.Components;

namespace Nazar.Rendering.Systems;

public class LineRenderSystem(World world) : ISystem<float>
{
    
    public void Update(float state)
    {
        var lineEntities = world.GetEntities()
            .With<LineComponent>()
            .AsSet();

        foreach (ref readonly var entity in lineEntities.GetEntities())
        {
            ref var lineComponent = ref entity.Get<LineComponent>();
            lineComponent.Draw();
        }
    }

    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
