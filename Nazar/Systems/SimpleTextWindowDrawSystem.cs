using Nazar.Components;
using Nazar.UIHandlers;


namespace Nazar.Systems;

/// <summary>
/// System responsible for drawing text windows in the world.
/// </summary>
public class SimpleTextWindowDrawSystem : BaseSystem<float>
{
    public SimpleTextWindowDrawSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var windowsToDraw = World.GetEntities().With<PositionComponent>().With<TextContentsComponent>().AsSet();
        foreach (ref readonly var entity in windowsToDraw.GetEntities())
        {
            ref var position = ref entity.Get<PositionComponent>();

            UIHandler.DrawTextWindow(ref textContent, ref position);
            ref var pose = ref entity.Get<PositionComponent>();
            ref var textContent = ref entity.Get<TextContentsComponent>();

                        UIHandler.DrawTextWindow(ref textContent, ref pose);

        }
    }
}
