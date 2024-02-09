using Nazar.Components;
using StereoKit;

namespace Nazar.Systems;

public class WindowRenderer : BaseSystem<float>
{
    public WindowRenderer(World world) : base(world) { }

    public override void Update(float state)
    {
        var windowEntities = World.GetEntities().With<WindowComponent>().With<TransformComponent>().AsSet();

        foreach (ref readonly var entity in windowEntities.GetEntities())
        {
            ref var window = ref entity.Get<WindowComponent>();
            ref var transform = ref entity.Get<TransformComponent>();
            UI.WindowBegin("Window", ref transform.Position, window.Size * U.cm, window.ShowHeader ? UIWin.Normal : UIWin.Body);
            // ... UI elements for the window ...
            UI.WindowEnd();
        }
    }
}
