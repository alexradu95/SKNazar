namespace Nazar.Systems.Animations;

public class AnimationRotationOnAxisSystem : ISystem<float>
{
    private readonly World _world;

    public AnimationRotationOnAxisSystem(World world)
    {
        _world = world;
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state)
    {
        var poseSet = _world.GetEntities().With<PoseComponent>().With<AnimationAxisComponent>().AsSet();
        foreach (ref readonly Entity entity in poseSet.GetEntities())
        {
            ref var pose = ref entity.Get<PoseComponent>();
            ref readonly var anim = ref entity.Get<AnimationAxisComponent>();

            pose.Value.orientation *= Quat.FromAngles(anim.Axis * (anim.Speed * Time.Stepf));
        }
    }

    public void Dispose() { }
}