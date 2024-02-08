using Nazar.Components;

namespace Nazar.Systems.Interactions;

public class ContentUpdateSystem : ISystem<float>
{
    private readonly IDisposable _buttonPressedSubscription;
    private readonly World _world;

    public ContentUpdateSystem(World world)
    {
        _world = world;
        _buttonPressedSubscription = _world.Subscribe<ButtonPressedMessage>(OnButtonPressed);
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state)
    {
        // Regular update logic (if any)
    }

    public void Dispose()
    {
        _buttonPressedSubscription.Dispose();
    }

    private void OnButtonPressed(in ButtonPressedMessage message)
    {
        var contentEntities = _world.GetEntities().With<IdComponent>().AsSet();
        foreach (ref readonly var entity in contentEntities.GetEntities())
        {
            ref var contentId = ref entity.Get<IdComponent>();
            if (contentId.Id == message.ButtonEntityId)
            {
                ref var textContent = ref entity.Get<TextContentsComponent>();
                textContent.TextContents = "Updated content for Button ID: " + message.ButtonEntityId;
            }
        }
    }
}