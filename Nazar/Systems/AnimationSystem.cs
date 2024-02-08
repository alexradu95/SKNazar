using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using StereoKit;
using World = DefaultEcs.World;

namespace Nazar.Systems;

public class AnimationSystem : ISystem<float> {
    private readonly World _world;

    public AnimationSystem(World world) {
        _world = world;
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state) {
        var poseSet = _world.GetEntities().With<PoseComponent>().With<AnimationComponent>().AsSet();
        foreach (ref readonly Entity entity in poseSet.GetEntities()) {
            ref var pose = ref entity.Get<PoseComponent>();
            ref readonly var anim = ref entity.Get<AnimationComponent>();

            pose.Value.orientation *= Quat.FromAngles(anim.Axis * (anim.Speed * Time.Stepf));
        }
    }

    public void Dispose() { }
}