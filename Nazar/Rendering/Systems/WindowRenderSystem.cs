

namespace Nazar.Rendering.Systems;

public class WindowRenderSystem(World world) : ISystem<float>
{
    public void Update(float state)
    {
        var windowEntities = world.GetEntities().With<WindowComponent>().With<TransformComponent>().AsSet();

        foreach (ref readonly var entity in windowEntities.GetEntities())
        {
            ref var window = ref entity.Get<WindowComponent>();
            ref var transform = ref entity.Get<TransformComponent>();
            UI.WindowBegin("Window", ref transform.Position, window.Size * U.cm, window.ShowHeader ? UIWin.Normal : UIWin.Body);
            UI.Label("default");
            UI.WindowEnd();
        }
    }

    public bool IsEnabled { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
