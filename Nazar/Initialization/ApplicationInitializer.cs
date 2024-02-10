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
        
        HandMenuInitializer.SetupHandMenu(world);
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
}
