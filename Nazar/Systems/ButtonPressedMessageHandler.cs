using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;

namespace Nazar.Systems;

/// <summary>
///     Handler responsible for processing button pressed messages.
/// </summary>
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
        foreach (var entity in _textEntities.GetEntities())
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
