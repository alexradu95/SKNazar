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
            UI.WindowBegin("Entity Configuration");
            UI.Label($"Entity ID: {entity.Id}");
            UI.WindowEnd();
        }
    }
    {
        var allEntities = _world.GetEntities().AsSet();
        foreach (ref readonly var entity in allEntities.GetEntities())
        {
            StringBuilder componentList = new StringBuilder();
            componentList.AppendLine($"Entity");

            foreach (var componentType in entity.GetComponentTypes())
            {
                var component = entity.Get(componentType);
                componentList.AppendLine($"- {componentType.Name}: {component}");
            }

            // Draw the debug window with the component list
            // This is a placeholder, replace with actual UI drawing code
            UI.WindowBegin("Debug", );
            Debug.DrawWindow(componentList.ToString());
        }
    }

    public bool IsEnabled { get; set; }

    public void Dispose()
    {
        // Assuming allEntities is a field now, otherwise, this needs to be adjusted
        allEntities.Dispose();
    }
}
