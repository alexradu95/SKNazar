using Nazar.Components;
using Nazar.UIHandlers;

namespace Nazar.Systems;

public class ButtonDrawSystem(World world) : BaseSystem<float>(world)
{
    public override void Update(float state)
    {
        var buttonsToDraw = World.GetEntities().With<DrawableComponent>().With<ButtonComponent>().AsSet();

        foreach (ref readonly var entity in buttonsToDraw.GetEntities())
        {
            ref var button = ref entity.Get<ButtonComponent>();
            ref var text = entity.Has<TextContentsComponent>() ? ref entity.Get<TextContentsComponent>() : new TextContentsComponent { TextContents = "Default Label" };
            ref var position = ref entity.Get<PositionComponent>();

            if (entity.Has<PositionComponent>())
            {
                UIHandler.DrawButton(ref button, ref position, ref text);
            }
            else
            {
                var defaultPosition = new PositionComponent { Value = new Pose(0, 0, 0, Quat.Identity) };
                UIHandler.DrawButton(ref button, ref defaultPosition, ref text);
            }
        }
    }
}
