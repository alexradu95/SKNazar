

namespace Nazar.Rendering.Systems;

public class ModelRenderSystem(World world) : ISystem<float>
{
    public void Update(float state)
    {
        var modelEntities = world.GetEntities()
            .With<ModelComponent>()
            .With<TransformComponent>()
            .AsSet();

        foreach (ref readonly var entity in modelEntities.GetEntities())
        {
            ref readonly var modelComponent = ref entity.Get<ModelComponent>();
            ref readonly var transform = ref entity.Get<TransformComponent>();
            modelComponent.Model.Draw(transform.ToMatrix(), Color.Black);
        }
    }

    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
