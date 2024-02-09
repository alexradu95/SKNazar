using DefaultEcs;
using Nazar.Components;
using Nazar.Messaging.Components;
using Nazar.Rendering.Components;
using StereoKit;

namespace Nazar.Factories;

public static class EntityBuilderExtensions
{
    public static Entity WithId(this Entity entity)
    {
        entity.Set(IdComponent.NewId());
        return entity;
    }

    public static Entity WithTransform(this Entity entity, Pose? position = null)
    {
        entity.Set<IsConfigurableComponent>();
        entity.Set(new TransformComponent { Position = position ?? new Pose(0, 0, 0, Quat.Identity) });
        return entity;
    }

    public static Entity WithButton(this Entity entity, string label)
    {
        entity.Set(new ButtonComponent());
        entity.Set(new TextComponent { Content = label ?? "Default Label" });
        entity.WithId();
        return entity;
    }

    public static Entity WithTextWindow(this Entity entity)
    {
        entity.Set(new WindowComponent());
        entity.WithId();
        return entity;
    }

    public static Entity WithMesh(this Entity entity, Mesh mesh)
    {
        entity.Set(new MeshComponent { Mesh = mesh });
        entity.WithId();
        return entity;
    }

    public static Entity WithModel(this Entity entity, Model model)
    {
        entity.Set(new ModelComponent { Model = model });
        entity.WithId();
        return entity;
    }

    public static Entity WithText(this Entity entity, string content)
    {
        entity.Set(new TextComponent { Content = content });
        entity.WithId();
        return entity;
    }

    public static Entity WithLine(this Entity entity, Vec3 start, Vec3 end)
    {
        entity.Set(new LineComponent { Start = start, End = end });
        entity.WithId();
        return entity;
    }

    public static Entity WithSubscriber(this Entity entity, string eventType)
    {
        entity.Set(new SubscriberComponent { EventName = eventType });
        entity.WithId();
        return entity;
    }
}
