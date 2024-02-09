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
        var button = EntityFactory.CreateButton(world, "Press Me!", new Pose(0.2f, 0, -0.5f, Quat.Identity));
        button.Set(new SubscriberComponent { EventName = "ButtonPressed" });
        
        var textWindow = EntityFactory.CreateTextWindow(world, "test", new Pose(-0.2f, 0, -0.5f, Quat.Identity));
        textWindow.Set(new SubscriberComponent { EventName = "ButtonPressed" });
        
        // Example Mesh entity
        EntityFactory.CreateMesh(world, Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f), new Pose(0.6f, 0, -0.5f, Quat.Identity));
        
        // Example Model entity
        EntityFactory.CreateModelFromFile(world, "StereoKit.glb", new Pose(0.8f, 0, -0.5f, Quat.Identity));
        
        // Example Text entity
        EntityFactory.CreateText(world, "Example Text", new Pose(-0.6f, 0, -0.5f, Quat.Identity));
        
        // Example Line entity
        EntityFactory.CreateLine(world, new Vec3(-0.8f, 0, -0.5f), new Vec3(-0.8f, 0.1f, -0.5f));
        
    }
}
