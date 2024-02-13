
namespace Nazar.Rendering.Systems;

public class TextRenderSystem(World world): ISystem<float>
{

    public void Update(float state)
    {
        var textEntities = world.GetEntities()
            .With<TextComponent>()
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

    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        // Dispose logic if necessary
    }
}
