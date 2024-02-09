using Nazar.Components;
using StereoKit;

namespace Nazar.Systems.Renderers;

public class TextRenderSystem : BaseSystem<float>
{
    public TextRenderSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var textEntities = World.GetEntities()
            .With<TextComponent>()
            .With<TransformComponent>()
            .AsSet();

        foreach (ref readonly var entity in textEntities.GetEntities())
        {
            ref readonly var textComponent = ref entity.Get<TextComponent>();
            ref readonly var transformComponent = ref entity.Get<TransformComponent>();
            Text.Add(textComponent.Content, transformComponent.ToMatrix());
        }
    }
}
