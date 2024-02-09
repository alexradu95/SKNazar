using Nazar.Components;

namespace Nazar.Systems;

public class ButtonInteractionSystem(World world) : BaseSystem<float>(world)
{
    public override void Update(float state)
    {
        var buttonEntities = World.GetEntities().With<ButtonComponent>().AsSet();

        foreach (ref readonly var entity in buttonEntities.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            if (!button.IsPressed) continue;
            var eventName = entity.Get<SubscriberComponent>().EventName;
            World.Publish(new ButtonPressedMessage { Message = "pressed", EventName = eventName });
            button.IsPressed = false;
        }
    }
}
