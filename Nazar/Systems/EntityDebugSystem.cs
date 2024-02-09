using DefaultEcs;
using Nazar.Components;
using System.Text;

namespace Nazar.Systems;

public class EntityDebugSystem : ISystem<float>
{
    private readonly World _world;

    public EntityDebugSystem(World world)
    {
        _world = world;
    }

    public void Update(float state)
    {
        var allEntities = _world.GetEntities().With<IsConfigurableComponent>().AsSet();
        foreach (ref readonly var entity in allEntities.GetEntities())
        {
            // Draw the debug window with a simple label to verify that the window is shown
            var pose = Pose.Identity;
            UI.WindowBegin("Entity Configuration", ref pose);
            UI.Label($"Entity ID: ");
            UI.WindowEnd();
        }
    }
    
    public bool IsEnabled { get; set; }

    public void Dispose()
    {

    }
}
