using Nazar.Components;
using Nazar.UIHandlers;

namespace Nazar.Systems;

public class ButtonRenderer : BaseSystem<float>
{
    public ButtonRenderer(World world) : base(world) { }

    public override void Update(float state)
    {
        var buttonsToRender = World.GetEntities().With<DrawableComponent>().With<PositionComponent>().With<ButtonComponent>().With<TextContentsComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToRender.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            ref var position = ref entity.Get<PositionComponent>();
            ref var text = ref entity.Get<TextContentsComponent>();
            UIHandler.DrawButton(ref button, ref position, ref text);
        }
    }
}
