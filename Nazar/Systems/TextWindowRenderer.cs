using Nazar.Components;
using Nazar.UIHandlers;

namespace Nazar.Systems;

public class TextWindowRenderer : BaseSystem<float>
{
    public TextWindowRenderer(World world) : base(world) { }

    public override void Update(float state)
    {
        var textWindowsToRender = World.GetEntities().With<DrawableComponent>().With<PositionComponent>().With<TextContentsComponent>().AsSet();

        foreach (ref readonly var entity in textWindowsToRender.GetEntities())
        {
            ref var textContent = ref entity.Get<TextContentsComponent>();
            ref var position = ref entity.Get<PositionComponent>();
            UIHandler.DrawTextWindow(ref textContent, ref position);
        }
    }
}
