using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using StereoKit;
using World = DefaultEcs.World;

namespace Nazar.Systems;

public class InteractionSystem : ISystem<float> {
    private readonly World _world;

    public InteractionSystem(World world) {
        _world = world;
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state) {
        var interactableSet = _world.GetEntities().With<PoseComponent>().With<InteractableComponent>().AsSet();
        foreach (ref readonly Entity entity in interactableSet.GetEntities()) {
            ref var pose = ref entity.Get<PoseComponent>();

            if (UI.Handle("Interactable", ref pose.Value, new Bounds(Vec3.Zero, Vec3.One * 0.1f))) {
                System.Console.WriteLine("Interacted with entity!");
            }
        }
    }

    public void Dispose() { }
}