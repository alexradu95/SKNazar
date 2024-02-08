using System;
using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using Nazar.Messages;
using StereoKit;
using World = DefaultEcs.World;

namespace Nazar.Systems;

public class ButtonInteractionSystem : ISystem<float>
{
    private readonly World _world;

    public ButtonInteractionSystem(World world)
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
                _world.Publish(new ButtonPressedMessage() { ButtonEntityId = buttonId });
            }
        }
    }

    public void Dispose() { }
}
