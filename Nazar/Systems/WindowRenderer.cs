using Nazar.Components;
using StereoKit;

namespace Nazar.Systems;

public class WindowRenderer : BaseSystem<float>
{
    public WindowRenderer(World world) : base(world) { }

    public override void Update(float state)
    {
        var windowEntities = World.GetEntities().With<WindowComponent>().AsSet();

        foreach (ref readonly var entity in windowEntities.GetEntities())
        {
            ref var window = ref entity.Get<WindowComponent>();
            UI.WindowBegin("Window", ref window.Pose, window.Size * U.cm, window.ShowHeader ? UIWin.Normal : UIWin.Body);
            // ... UI elements for the window ...
            UI.WindowEnd();
        }
    }
}
