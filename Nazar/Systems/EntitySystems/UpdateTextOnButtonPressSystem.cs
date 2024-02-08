namespace Nazar.Systems.EntitySystems;

public class UpdateTextOnButtonPressSystem : ISystem<float>
{
    private readonly World _world;
    private readonly IDisposable _buttonPressedSubscription;

    public UpdateTextOnButtonPressSystem(DefaultEcs.World world)
    {
        _world = world;
        _buttonPressedSubscription = _world.Subscribe<ButtonPressedMessage>(OnButtonPressed);
    }

    public bool IsEnabled { get; set; } = true;

    private void OnButtonPressed(in ButtonPressedMessage message)
    {
        var textEntities = _world.GetEntities().With<TextContentsComponent>().AsSet();
        foreach (ref readonly Entity entity in textEntities.GetEntities())
        {
            if (entity.Has<AssociatedButtonComponent>() && entity.Get<AssociatedButtonComponent>().ButtonId == message.ButtonEntityId)
            {
                ref var textContent = ref entity.Get<TextContentsComponent>();
                textContent.TextContents = $"Button {message.ButtonEntityId} Pressed!";
            }
        }
    }

    public void Update(float state) { }

    public void Dispose()
    {
        _buttonPressedSubscription.Dispose();
    }
}
