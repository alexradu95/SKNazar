using Nazar.Components;
using Nazar.Factories;

namespace Nazar.Initialization;

public static class ApplicationInitializer
{
    public static bool Initialize(out World world, out List<ISystem<float>> systems)
    {
        if (!SK.Initialize(CreateStereoKitSettings()))
        {
            world = null;
            systems = null;
            return false;
        }

        world = new World();
        systems = [];

        CreateDemoEntities(world);
        SystemsInitializer.InitializeSystems(world, systems);

        return true;
    }

    private static SKSettings CreateStereoKitSettings()
    {
        return new SKSettings
        {
            appName = "Nazar",
            assetsFolder = "Assets"
        };
    }

    private static void CreateDemoEntities(World world)
    {
private static void CreateDemoEntities(World world)
{
        var button = new EntityBuilder(world).WithButton("Press Me!").WithTransform(new Pose(0.0f, 0, -0.5f, Quat.Identity)).Build();
        button.Set(new SubscriberComponent { EventName = "ButtonPressed" });

        var textWindow = new EntityBuilder(world).WithTextWindow().WithTransform(new Pose(-0.3f, 0, -0.5f, Quat.Identity)).Build();
        textWindow.Set(new SubscriberComponent { EventName = "ButtonPressed" });

        // Example Mesh entity
        new EntityBuilder(world).WithMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f)).WithTransform(new Pose(0.3f, 0, -0.5f, Quat.Identity)).Build();

        // Example Model entity
        new EntityBuilder(world).WithModel(Model.FromFile("StereoKit.glb")).WithTransform(new Pose(0.6f, 0, -0.5f, Quat.Identity)).Build();

        // Example Text entity
        new EntityBuilder(world).WithText("Example Text").WithTransform(new Pose(-0.9f, 0, -0.5f, Quat.Identity)).Build();

        // Example Line entity
        new EntityBuilder(world).WithLine(new Vec3(-1.2f, 0, -0.5f), new Vec3(-1.2f, 0.1f, -0.5f)).Build();
    }
}
