using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;

namespace Nazar.Systems;

public class ModelsDrawSystem : ISystem<float> {
    private readonly World _world;

    public ModelsDrawSystem(World world) {
        _world = world;
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state) {
        var modelSet = _world.GetEntities().With<PoseComponent>().With<ModelComponent>().AsSet();
        foreach (ref readonly Entity entity in modelSet.GetEntities()) {
            ref var pose = ref entity.Get<PoseComponent>();
            ref readonly var model = ref entity.Get<ModelComponent>();

            model.Value.Draw(pose.Value.ToMatrix());
        }
    }

    public void Dispose() { }
}