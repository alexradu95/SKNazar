using Nazar.Components;
using Nazar.UIHandlers;

namespace Nazar.Systems;

/// <summary>
///     System responsible for drawing buttons in the world.
/// </summary>
public class ButtonDrawSystem(World world) : BaseSystem<float>(world)
{
    public override void Update(float state)
    {
        var buttonsToDraw = World.GetEntities().With<PositionComponent>().With<ButtonComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToDraw.GetEntities())
        {
            ref var position = ref entity.Get<PositionComponent>();
            ref var button = ref entity.Get<ButtonComponent>();

            UIHandler.DrawButton(ref button, ref position);
        }
    }
}