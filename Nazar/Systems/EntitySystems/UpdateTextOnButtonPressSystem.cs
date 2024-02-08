using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using Nazar.Messages;

namespace Nazar.Systems;

public class UpdateTextOnButtonPressSystem : ISystem<float>
{
    private readonly World _world;
    private readonly Entity _textEntity;
    private int numberOfPresses = 0;

    public UpdateTextOnButtonPressSystem(World world, Entity textEntity)
    {
        _world = world;
        _textEntity = textEntity;

        // Subscribe to ButtonPressedMessage
        _world.Subscribe<ButtonPressedMessage>(OnButtonPressed);
    }

    public bool IsEnabled { get; set; } = true;

    private void OnButtonPressed(in ButtonPressedMessage message)
    {
        // Update the TextContentsComponent of the target entity
        if (_textEntity.Has<TextContentsComponent>())
        {
            ref var textContent = ref _textEntity.Get<TextContentsComponent>();
            numberOfPresses++;
            textContent.TextContents = $"Button Pressed! {numberOfPresses} times.";

        }
    }

    public void Update(float state)
    {
        // This system might not need to do anything in its Update method
        // since it reacts to messages instead.
    }

    public void Dispose()
    {
        // Unsubscribe to clean up
        // _world.Unsubscribe<ButtonPressedMessage>(OnButtonPressed);
    }
}
