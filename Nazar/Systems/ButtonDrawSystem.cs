using Nazar.Components;

namespace Nazar.Systems;

public class ButtonDrawSystem : BaseSystem<float>
{
    public ButtonDrawSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var buttonsToDraw = World.GetEntities().With<PositionComponent>().With<ButtonComponent>().AsSet();
        
        foreach (ref readonly var entity in buttonsToDraw.GetEntities())
        {
            ref var pose = ref entity.Get<PositionComponent>();
            ref var button = ref entity.Get<ButtonComponent>();

            UI.WindowBegin("Window", ref pose.Value, new Vec2(20, 0) * U.cm);
            if (UI.Button(button.Label))
            {
                World.Publish(new ButtonPressedMessage() { Message = "Button Pressed!" });
            }
            UI.WindowEnd();
        }
    }
}
