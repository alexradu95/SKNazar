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
            ref var textComponent = ref entity.Get<TextComponent>();
            textComponent.Draw();
        }
    }
}
