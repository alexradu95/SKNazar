using Nazar.Components;
using Nazar.UIHandlers;

namespace Nazar.Systems;

/// <summary>
///     System responsible for drawing text windows in the world.
/// </summary>
public class TextWindowDrawSystem(World world) : BaseSystem<float>(world)
{
    public override void Update(float state)
    {
        var windowsToDraw = World.GetEntities().With<DrawableComponent>().With<TextContentsComponent>().AsSet();
        foreach (ref readonly var entity in windowsToDraw.GetEntities())
        {
            ref var textContent = ref entity.Get<TextContentsComponent>();

            if (entity.Has<PositionComponent>())
            {
                ref var position = ref entity.Get<PositionComponent>();
                UIHandler.DrawTextWindow(ref textContent, ref position);
            }
            else
            {
                var defaultPosition = new PositionComponent { Value = new Pose(0, 0, 0, Quat.Identity) };
                UIHandler.DrawTextWindow(ref textContent, ref defaultPosition);
            }
        }
    }
}
