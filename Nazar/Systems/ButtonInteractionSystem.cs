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
            // Logic to determine if the button is pressed goes here
            // If pressed, invoke the action
            // button.OnPressed?.Invoke();
        }
    }
}
