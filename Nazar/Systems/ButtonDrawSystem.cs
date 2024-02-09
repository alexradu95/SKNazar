using Nazar.Components;
using Nazar.UIHandlers;

namespace Nazar.Systems;

public class ButtonDrawSystem(World world) : BaseSystem<float>(world)
{
    public override void Update(float state)
    {
        var buttonsToDraw = World.GetEntities().With<PositionComponent>().With<ButtonComponent>().With<TextContentsComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToDraw.GetEntities())
        {
            ref var position = ref entity.Get<PositionComponent>();
            ref var button = ref entity.Get<ButtonComponent>();
            ref var text = ref entity.Get<TextContentsComponent>();

            UIHandler.DrawButton(ref button, ref position, ref text);
        }
    }
}