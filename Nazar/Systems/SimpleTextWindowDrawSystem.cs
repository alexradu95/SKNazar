using Nazar.Components;
using Nazar.UserInterfaces;

namespace Nazar.Systems;


        public class SimpleTextWindowDrawSystem : BaseSystem<float>

/// <summary>
/// System responsible for drawing text windows in the world.
/// </summary>
{
    public SimpleTextWindowDrawSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var windowsToDraw = World.GetEntities().With<PositionComponent>().With<TextContentsComponent>().AsSet();
        foreach (ref readonly var entity in windowsToDraw.GetEntities())
        {
            ref var pose = ref entity.Get<PositionComponent>();
            ref var textContent = ref entity.Get<TextContentsComponent>();

            UIHandler.DrawTextWindow(ref pose, ref textContent);
        }
    }
}
