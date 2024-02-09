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
        var allEntities = _world.GetEntities().AsSet();
        foreach (ref readonly var entity in allEntities.GetEntities())
        {
            StringBuilder componentList = new StringBuilder();
            componentList.AppendLine($"Entity {entity.EntityId}:");

            foreach (var componentType in entity.GetComponentTypes())
            {
                var component = entity.Get(componentType);
                componentList.AppendLine($"- {componentType.Name}: {component}");
            }

            // Draw the debug window with the component list
            // This is a placeholder, replace with actual UI drawing code
            Debug.DrawWindow(componentList.ToString());
        }
    }

    public bool IsEnabled { get; set; }

    public void Dispose()
    {
        allEntities.Dispose();
    }
}
