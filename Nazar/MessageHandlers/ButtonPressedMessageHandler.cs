using DefaultEcs;
using Nazar.Components;

namespace Nazar.MessageHandlers;

public class ButtonPressedMessageHandler : ISystem<float>
{
    private readonly World _world;
    private readonly EntitySet _textEntities;
    private readonly IDisposable _messageSubscription;

    public ButtonPressedMessageHandler(World world)
    {
        _world = world;
        _textEntities = world.GetEntities().With<TextContentsComponent>().AsSet();
        _messageSubscription = world.Subscribe<ButtonPressedMessage>(HandleButtonPressedMessage);
    }

    public void Update(float state)
    {
        // This method is intentionally left empty as the message handling is event-driven.
    }

    private void HandleButtonPressedMessage(in ButtonPressedMessage message)
    {
        var subscribedEntities = _world.GetEntities().With<SubscriberComponent>(c => c.EventName == message.EventName).With<TextContentsComponent>().AsSet();
        foreach (ref readonly var entity in subscribedEntities.GetEntities())
        {
            ref var textContent = ref entity.Get<TextContentsComponent>();
            textContent.TextContents = message.Message;
        }
    }

    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        _messageSubscription.Dispose();
        _textEntities.Dispose();
    }
}
