using Nazar.Components;
using StereoKit;

namespace Nazar.Systems.Renderers;

public class ModelRenderSystem : BaseSystem<float>
{
    public ModelRenderSystem(World world) : base(world) { }

    public override void Update(float state)
    {
        var modelEntities = World.GetEntities()
            .With<ModelComponent>()
            .With<TransformComponent>()
            .AsSet();

        foreach (ref readonly var entity in modelEntities.GetEntities())
        {
            ref readonly var modelComponent = ref entity.Get<ModelComponent>();
            ref readonly var transform = ref entity.Get<TransformComponent>();
            modelComponent.Model.Draw(Material.Default, transform.ToMatrix());
        }
    }
}
