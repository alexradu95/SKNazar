using Nazar.Factories;

namespace Nazar;

internal class Program
{
    private static readonly World World = new();
    private static readonly List<ISystem<float>> Systems = new();

    private static void Main(string[] args)
    {
        if (InitializeNazar()) RunApplication();
    }

    private static bool InitializeNazar()
    {
        if (!SK.Initialize(CreateStereoKitSettings())) return false;

        CreateEntities();
        
        InitializeSystems();
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

    private static void InitializeSystems()
    {
        Systems.Add(new ButtonDrawSystem(World));
        Systems.Add(new TextMessageUpdateSystem(World));
        Systems.Add(new SimpleTextWindowDrawSystem(World));
    }

    private static void CreateEntities()
    {
        EntityFactory.CreateButton(World, "Press Me!", new Pose(0.2f, 0, -0.5f, Quat.Identity));
        EntityFactory.CreateTextWindow(World, "test", new Pose(-0.2f, 0, -0.5f, Quat.Identity));
    }

    private static void RunApplication()
    {
        SK.Run(() =>
        {
            var deltaTime = Time.Stepf;
            foreach (var system in Systems)
                if (system.IsEnabled)
                    system.Update(deltaTime);
        });
        Cleanup();
    }

    private static void Cleanup()
    {
        Systems.ForEach(system => system.Dispose());
        World.Dispose();
        SK.Shutdown();
    }
}