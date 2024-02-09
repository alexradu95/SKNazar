using DefaultEcs;
using Nazar.Components;

namespace Nazar.Factories;

public static class EntityFactory
{
    public static Entity CreateButton(World world, string label, Pose? position)
    {
        var entity = world.CreateEntity();
        entity.Set(new ButtonComponent());
        entity.Set(new TextContentsComponent() { TextContents = label ?? "Default Label" });
        entity.Set(new TransformComponent() { Position = position ?? new Pose(0, 0, 0, Quat.Identity) });
        return entity;
    }
    
    public static Entity CreateTextWindow(World world, string text, Pose? position)
    {
        var entity = world.CreateEntity();
        entity.Set(new TextContentsComponent { TextContents = text ?? "Default Text" });
        entity.Set(new TransformComponent { Position = position ?? new Pose(0, 0, 0, Quat.Identity) });

        return entity;
    }
}
