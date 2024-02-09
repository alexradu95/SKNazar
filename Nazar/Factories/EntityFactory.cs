using DefaultEcs;
using Nazar.Components;

namespace Nazar.Factories;

public static class EntityFactory
{
    public static Entity CreateButton(World world, string label, Pose position)
    {
        var entity = world.CreateEntity();
        entity.Set(new ButtonComponent());
        entity.Set(new TextContentsComponent() { TextContents = label ?? "Default Label" });
        entity.Set(new PositionComponent { Value = position });
        entity.Set(new DrawableComponent());
        return entity;
    }
    
    public static Entity CreateTextWindow(World world, string text, Pose position)
    {
        var entity = world.CreateEntity();
        entity.Set(new TextContentsComponent { TextContents = text ?? "Default Text" });
        entity.Set(new PositionComponent { Value = position });
        entity.Set(new DrawableComponent());
        return entity;
    }
}
