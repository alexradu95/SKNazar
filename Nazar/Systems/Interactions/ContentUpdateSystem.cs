using System;
using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using Nazar.Messages;

namespace Nazar.Systems;

/// <summary>
/// System that updates content based on button press messages.
/// </summary>
public class ContentUpdateSystem : ISystem<float>
{
    private readonly DefaultEcs.World _world;
    private readonly IDisposable _subscription;

    public ContentUpdateSystem(DefaultEcs.World world)
    {
        _world = world;
        _subscription = _world.Subscribe<ButtonPressedMessage>(OnButtonPressed);
    }

    public bool IsEnabled { get; set; } = true;

    private void OnButtonPressed(in ButtonPressedMessage message)
    {
        var contentEntities = _world.GetEntities().With<IdComponent>().AsSet();
        foreach (ref readonly Entity entity in contentEntities.GetEntities())
        {
            ref var contentId = ref entity.Get<IdComponent>();
            if (contentId.Id == message.ButtonEntityId)
            {
                ref var textContent = ref entity.Get<TextContentsComponent>();
                textContent.TextContents = "Updated content for Button ID: " + message.ButtonEntityId;
            }
        }
    }

    public void Update(float state)
    {
        // Regular update logic (if any)
    }

    public void Dispose()
    {
        _subscription.Dispose();
    }
}