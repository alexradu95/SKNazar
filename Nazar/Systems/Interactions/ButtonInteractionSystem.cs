namespace Nazar.Systems.Interactions;

/// <summary>
/// System that handles interactions with buttons and publishes button press messages.
/// </summary>
public class ButtonInteractionSystem : ISystem<float>
{
    private readonly DefaultEcs.World _world;

    public ButtonInteractionSystem(DefaultEcs.World world)
    {
        _world = world;
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state)
    {
        var buttonSet = _world.GetEntities().With<ButtonComponent>().With<IdComponent>().AsSet();
        foreach (ref readonly Entity entity in buttonSet.GetEntities())
        {
            ref var ui = ref entity.Get<ButtonComponent>();
            Guid buttonId = entity.Get<IdComponent>().Id;
            if (UI.Button(ui.Label))
            {
                _world.Publish(new ButtonPressedMessage { ButtonEntityId = buttonId });
            }
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}