namespace Nazar.Systems;

public class MoveableEntitySystem(World world) : ISystem<float>
{
    public bool IsEnabled { get; set; } = true;

    public void Update(float state) {
        var interactableSet = world.GetEntities().With<PoseComponent>().With<MoveableComponent>().AsSet();
        foreach (ref readonly Entity entity in interactableSet.GetEntities()) {
            ref var pose = ref entity.Get<PoseComponent>();

            if (UI.Handle($"MoveableEntitySystem", ref pose.Value, new Bounds(Vec3.Zero, Vec3.One * 0.1f))) {
                System.Console.WriteLine("Interacted with entity!");
            }
        }
    }

    public void Dispose() { }
}