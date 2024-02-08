using Nazar.Components;
using Nazar.UIHandlers;


namespace Nazar.Systems;

public class ButtonDrawSystem : BaseSystem<float>
{

/// <summary>
/// System responsible for drawing buttons in the world.
/// </summary>
public class ButtonDrawSystem : BaseSystem<float>
{
    public ButtonDrawSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var buttonsToDraw = World.GetEntities().With<PositionComponent>().With<ButtonComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToDraw.GetEntities())
        {
            ref var position = ref entity.Get<PositionComponent>();
            ref var pose = ref entity.Get<PositionComponent>();
            ref var button = ref entity.Get<ButtonComponent>();

            UIHandler.DrawButton(ref button, ref position);
        }
    }
}
