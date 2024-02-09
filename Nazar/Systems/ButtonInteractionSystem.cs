using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using Nazar.Messaging.Components;
using Nazar.Rendering.Components;

namespace Nazar.Systems;

public class ButtonInteractionSystem(World world) : ISystem<float>
{
    public void Update(float state)
    {
        var buttonEntities = world.GetEntities().With<ButtonComponent>().AsSet();

        foreach (ref readonly var entity in buttonEntities.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            if (!button.IsPressed) continue;
            var eventName = entity.Get<SubscriberComponent>().EventName;
            world.Publish(new ButtonPressedMessage { Message = "pressed", EventName = eventName });
            button.IsPressed = false;
        }
    }

    public bool IsEnabled { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
