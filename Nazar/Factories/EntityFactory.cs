using System.IO;
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
        entity.Set(new WindowComponent());
        entity.Set(new TransformComponent { Position = position ?? new Pose(0, 0, 0, Quat.Identity) });
        return entity;
    }

    public static Entity CreateMesh(World world, Mesh mesh, Pose? position)
    {
        var entity = world.CreateEntity();
        entity.Set(new MeshComponent { Mesh = mesh });
        entity.Set(new TransformComponent { Position = position ?? new Pose(0, 0, 0, Quat.Identity)});
        return entity;
    }

    public static Entity CreateModelFromFile(World world, string modelPath, Pose? position)
    {
        var entity = world.CreateEntity();
        var model = Model.FromFile(modelPath);
        entity.Set(new ModelComponent { Model = model });
        entity.Set(new TransformComponent { Position = position ?? new Pose(0, 0, 0, Quat.Identity)});
        return entity;
    }

    public static Entity CreateText(World world, string content, Pose? position)
    {
        var entity = world.CreateEntity();
        entity.Set(new TextComponent { Content = content });
        entity.Set(new TransformComponent { Position = position ?? new Pose(0, 0, 0, Quat.Identity)});
        return entity;
    }

    public static Entity CreateLine(World world, Vec3 start, Vec3 end)
    {
        var entity = world.CreateEntity();
        entity.Set(new LineComponent { Start = start, End = end });
        return entity;
    }
}
