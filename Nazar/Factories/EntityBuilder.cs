using DefaultEcs;
using Nazar.Components;

namespace Nazar.Factories;

public class EntityBuilder
{
    private readonly World _world;
    private readonly Entity _entity;

    public EntityBuilder(World world)
    {
        _world = world;
        _entity = _world.CreateEntity();
    }

    public EntityBuilder WithTransform(Pose? position = null)
    {
        _entity.Set(new TransformComponent { Position = position ?? new Pose(0, 0, 0, Quat.Identity) });
        return this;
    }

    public EntityBuilder WithButton(string label)
    {
        _entity.Set(new ButtonComponent());
        _entity.Set(new TextContentsComponent { TextContents = label ?? "Default Label" });
        return this;
    }

    public EntityBuilder WithTextWindow()
    {
        _entity.Set(new WindowComponent());
        return this;
    }

    public EntityBuilder WithMesh(Mesh mesh)
    {
        _entity.Set(new MeshComponent { Mesh = mesh });
        return this;
    }

    public EntityBuilder WithModel(Model model)
    {
        _entity.Set(new ModelComponent { Model = model });
        return this;
    }

    public EntityBuilder WithText(string content)
    {
        _entity.Set(new TextComponent { Content = content });
        return this;
    }

    public EntityBuilder WithLine(Vec3 start, Vec3 end)
    {
        _entity.Set(new LineComponent { Start = start, End = end });
        return this;
    }

    public Entity Build()
    {
        return _entity;
    }
}
