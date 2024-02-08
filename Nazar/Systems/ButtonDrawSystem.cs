using Nazar.Components;
using Nazar.UserInterfaces;

namespace Nazar.Systems;

public class ButtonDrawSystem : BaseSystem<float>
{

/// <summary>
/// System responsible for drawing buttons in the world.
/// </summary>
    public ButtonDrawSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var buttonsToDraw = World.GetEntities().With<PositionComponent>().With<ButtonComponent>().AsSet();
        
        foreach (ref readonly var entity in buttonsToDraw.GetEntities())
        {
            ref var pose = ref entity.Get<PositionComponent>();
            ref var button = ref entity.Get<ButtonComponent>();

            UIHandler.DrawButton(ref pose, ref button, World);
        }
    }
}
