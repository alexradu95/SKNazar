namespace Nazar.Systems.EntitySystems;

public class UpdateTextOnButtonPressSystem : ISystem<float>
{
    private readonly World _world;
    private readonly Entity _textEntity;
    private int _numberOfPresses;
    private readonly IDisposable _buttonPressedSubscription;

    public UpdateTextOnButtonPressSystem(DefaultEcs.World world, Entity textEntity)
    {
        _world = world;
        _textEntity = textEntity;
        _buttonPressedSubscription = _world.Subscribe<ButtonPressedMessage>(OnButtonPressed);
    }
    

    public bool IsEnabled { get; set; } = true;

    private void OnButtonPressed(in ButtonPressedMessage message)
    {
        if (_textEntity.Has<TextContentsComponent>())
        {
            ref var textContent = ref _textEntity.Get<TextContentsComponent>();
            _numberOfPresses++;
            textContent.TextContents = $"Button Pressed! {_numberOfPresses} times.";
        }
    }

    public void Update(float state) { }

    public void Dispose()
    {
        _buttonPressedSubscription.Dispose();
    }
}