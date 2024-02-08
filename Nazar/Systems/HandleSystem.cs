using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using StereoKit;
using World = DefaultEcs.World;

namespace Nazar.Systems;

public class HandleSystem : ISystem<float> {
    private readonly World _world;

    public HandleSystem(World world) {
        _world = world;
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state) {
        var handleSet = _world.GetEntities().With<PoseComponent>().With<ModelComponent>().AsSet();
        foreach (ref readonly Entity entity in handleSet.GetEntities()) {
            ref var pose = ref entity.Get<PoseComponent>();
            ref readonly var model = ref entity.Get<ModelComponent>();

            UI.Handle("Cube", ref pose.Value, model.Value.Bounds);
        }
    }

    public void Dispose() { }
}