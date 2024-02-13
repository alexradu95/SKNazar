
namespace Nazar.Rendering.Systems;

public class MeshRenderSystem(World world) : ISystem<float>
{
    public void Update(float state)
    {
        var meshEntities = world.GetEntities().With<MeshComponent>().With<TransformComponent>().AsSet();
        foreach (ref readonly var entity in meshEntities.GetEntities())
        {
            ref readonly var meshComponent = ref entity.Get<MeshComponent>();
            ref readonly var transformComponent = ref entity.Get<TransformComponent>();
            meshComponent.Mesh.Draw(Material.Default, transformComponent.ToMatrix(), Color.White);
        }
    }

    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
