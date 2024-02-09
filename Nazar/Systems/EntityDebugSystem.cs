using DefaultEcs;
using Nazar.Components;
using System.Text;

namespace Nazar.Systems;

public class EntityDebugSystem : ISystem<float>
{
    private readonly World _world;
    private bool _isActive = false;
    private float _windowOffsetY = 0.0f;

    public EntityDebugSystem(World world)
    {
        _world = world;
    }

    public void Update(float state)
    {
        if (_isActive)
        {
            var allEntities = _world.GetEntities().With<IsConfigurableComponent>().AsSet();
            foreach (ref readonly var entity in allEntities.GetEntities())
            {
                var pose = new Pose(0.0f, _windowOffsetY, 0.0f, Quat.Identity);
                UI.WindowBegin("Entity Configuration", ref pose);
                UI.Label($"Entity ID");
                UI.WindowEnd();
                _windowOffsetY += 0.1f; // Adjust the offset for the next window
            }
            _windowOffsetY = 0.0f; // Reset the offset after drawing all windows
        }
    }
    

    public void ToggleActive()
    {
        _isActive = !_isActive;
    }

    public bool IsEnabled { get; set; }

    public void Dispose()
    {
        // Dispose logic if necessary

    }
}
