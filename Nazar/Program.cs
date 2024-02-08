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
        Systems.Add(new ModelsDrawSystem(World));
        Systems.Add(new MoveableEntitySystem(World));
        Systems.Add(new ButtonInteractionSystem(World));
        Systems.Add(new SimpleTextWindowDrawSystem(World));
        Systems.Add(new UpdateTextOnButtonPressSystem(World));
    }

    private static void CreateEntities()
    {
        CreateCube();
        CreateMovableTextWindow();
        CreateButton();
    }

    private static void CreateCube()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new ModelComponent
            { Value = Model.FromMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f), Default.MaterialUI) });
    }

    private static void CreateMovableTextWindow()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(-0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new MoveableComponent());
        entity.Set(new TextContentsComponent { TextContents = "test" });
    }

    private static void CreateButton()
    {
        var buttonEntity = World.CreateEntity();
        buttonEntity.Set(new ButtonComponent { Label = "Press Me!" });
        buttonEntity.Set(new IdComponent { Id = Guid.NewGuid() });
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