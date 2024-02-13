
using Nazar.Messaging.Components;
using ButtonComponent = Nazar.Rendering.Components.ButtonComponent;

namespace Nazar.Rendering.Systems;

public class ButtonRenderSystem(World world) : ISystem<float>
{

    public void Update(float state)
    {
        var buttonsToRender = world.GetEntities().With<TransformComponent>().With<SubscriberComponent>().With<IdComponent>().With<ButtonComponent>().With<TextComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToRender.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            ref var position = ref entity.Get<TransformComponent>();
            ref var text = ref entity.Get<TextComponent>();
            button.IsPressed = UI.Button(text.Content);
        }
    }

    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        // Dispose logic if necessary
    }
}
