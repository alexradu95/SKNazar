using Nazar.Components;

namespace Nazar.Systems;

public class ButtonRenderSystem : BaseSystem<float>
{
    public ButtonRenderSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var buttonsToRender = World.GetEntities().With<TransformComponent>().With<ButtonComponent>().With<TextContentsComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToRender.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            ref var position = ref entity.Get<TransformComponent>();
            ref var text = ref entity.Get<TextContentsComponent>();
            button.IsPressed = UI.Button(text.TextContents);
        }
    }
}
