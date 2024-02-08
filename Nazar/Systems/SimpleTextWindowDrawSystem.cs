using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using Nazar.Components.Properties;
using StereoKit;
using World = DefaultEcs.World;

namespace Nazar.Systems;

public class SimpleTextWindowDrawSystem(World world) : ISystem<float>
{
    public bool IsEnabled { get; set; } = true;

    public void Update(float state) {
        var windowsToDraw = world.GetEntities().With<PoseComponent>().With<TextContentsComponent>().AsSet();
        foreach (ref readonly Entity entity in windowsToDraw.GetEntities()) {
            ref var pose = ref entity.Get<PoseComponent>();
            ref var textContent = ref entity.Get<TextContentsComponent>();

            UI.WindowBegin("Window", ref pose.Value, new Vec2(20, 0) * U.cm, UIWin.Normal);
                UI.Label(textContent.TextContents);
            UI.WindowEnd();
        }
    }

    public void Dispose() { }
}