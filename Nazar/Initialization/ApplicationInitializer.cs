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

        CreateEntities(world);
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

    private static void CreateEntities(World world)
    {
        EntityFactory.CreateButton(world, "Press Me!", new Pose(0.2f, 0, -0.5f, Quat.Identity));
        var textWindow1 = EntityFactory.CreateTextWindow(world, "test", new Pose(-0.2f, 0, -0.5f, Quat.Identity));
        textWindow1.Set(new SubscriberComponent { EventName = "ButtonPressed" });
        EntityFactory.CreateTextWindow(world, "new text window", new Pose(-0.4f, 0, -0.5f, Quat.Identity));
    }
}
