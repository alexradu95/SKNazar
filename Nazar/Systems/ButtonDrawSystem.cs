using Nazar.Components;

namespace Nazar.Systems;

public class ButtonDrawSystem(World world) : ISystem<float>
{
    public bool IsEnabled { get; set; } = true;

    public void Update(float state)
    {
        var buttonsToDraw = world.GetEntities().With<PoseComponent>().With<ButtonComponent>().AsSet();
        
        foreach (ref readonly var entity in buttonsToDraw.GetEntities())
        {
            ref var pose = ref entity.Get<PoseComponent>();
            ref var button = ref entity.Get<ButtonComponent>();

            UI.WindowBegin("Window", ref pose.Value, new Vec2(20, 0) * U.cm);
            if (UI.Button(button.Label))
            {
                // publish a new ButtonPressedMessage into the world
                //Hub.Default.Publish(new ButtonPressedMessage() { Message = "Button Pressed!"});
            }
            UI.WindowEnd();
        }
    }

    public void Dispose()
    {
    }
}