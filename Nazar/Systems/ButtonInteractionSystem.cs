using Nazar.Components;
using DefaultEcs;

namespace Nazar.Systems;

public class ButtonInteractionSystem : BaseSystem<float>
{
    public ButtonInteractionSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var buttonEntities = World.GetEntities().With<ButtonComponent>().AsSet();

        foreach (ref readonly var entity in buttonEntities.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            if (button.IsPressed)
            {
                // Publish a ButtonPressedMessage when the button is pressed
                World.Publish(new ButtonPressedMessage { Message = button.Label + " pressed" });
                button.IsPressed = false; // Reset the IsPressed state
            }
            
        }
    }
}
