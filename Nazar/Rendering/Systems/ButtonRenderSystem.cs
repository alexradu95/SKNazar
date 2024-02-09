
namespace Nazar.Rendering.Systems;

public class ButtonRenderSystem(World world) : ISystem<float>
{

    public void Update(float state)
    {
        var buttonsToRender = world.GetEntities().With<TransformComponent>().With<ButtonComponent>().With<TextContentsComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToRender.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            ref var position = ref entity.Get<TransformComponent>();
            ref var text = ref entity.Get<TextContentsComponent>();
            button.IsPressed = UI.Button(text.TextContents);
        }
    }

    public bool IsEnabled { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
