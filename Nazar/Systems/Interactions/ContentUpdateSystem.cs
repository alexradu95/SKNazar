using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using Nazar.Messages;

namespace Nazar.Systems;

public class ContentUpdateSystem : ISystem<float>
{
    private readonly World _world;

    public ContentUpdateSystem(World world)
    {
        _world = world;
        _world.Subscribe<ButtonPressedMessage>(OnButtonPressed);
    }

    private void OnButtonPressed(in ButtonPressedMessage message)
    {
        // Example: Update entities associated with the pressed button
        // This requires a way to link content entities to button IDs, such as a component
        var contentEntities = _world.GetEntities().With<IdComponent>().AsSet();
        foreach (ref readonly Entity entity in contentEntities.GetEntities())
        {
            ref var contentId = ref entity.Get<IdComponent>();
            if (contentId.Id == message.ButtonEntityId)
            {
                // Found the content entity associated with the pressed button
                ref var textContent = ref entity.Get<TextContentsComponent>();
                textContent.TextContents = "Updated content for Button ID: " + message.ButtonEntityId;
            }
        }
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state)
    {
        // Regular update logic (if any)
    }

    public void Dispose()
    {
        // Unsubscribe to clean up
        // _world.Unsubscribe<ButtonPressedMessage>(OnButtonPressed);
    }
}
