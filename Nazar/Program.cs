namespace Nazar;

class Program
{
    private static readonly World World = new World();
    private static readonly List<ISystem<float>> Systems = new List<ISystem<float>>();

    static void Main(string[] args)
    {
        if (InitializeNazar())
        {
            RunApplication();
        }
    }

    static bool InitializeNazar()
    {
        if (!SK.Initialize(CreateStereoKitSettings()))
        {
            return false;
        }

        CreateEntities();
        InitializeSystems();
        return true;
    }

    static SKSettings CreateStereoKitSettings()
    {
        return new SKSettings
        {
            appName = "Nazar",
            assetsFolder = "Assets",
        };
    }

    static void InitializeSystems()
    {
        Systems.Add(new ModelsDrawSystem(World));
        Systems.Add(new MoveableEntitySystem(World));
        Systems.Add(new ButtonInteractionSystem(World));
        Systems.Add(new SimpleTextWindowDrawSystem(World));
        Systems.Add(new UpdateTextOnButtonPressSystem(World));
    }

    static void CreateEntities()
    {
        CreateCube();
        CreateMovableTextWindow();
        CreateButton();
    }

    static void CreateCube()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new ModelComponent { Value = Model.FromMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f), Default.MaterialUI) });
    }

    static void CreateMovableTextWindow()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(-0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new MoveableComponent());
        entity.Set(new TextContentsComponent { TextContents = "test" });
    }

    static void CreateButton()
    {
        var buttonEntity = World.CreateEntity();
        buttonEntity.Set(new ButtonComponent { Label = "Press Me!" });
        buttonEntity.Set(new IdComponent { Id = Guid.NewGuid() });
    }

    static void RunApplication()
    {
        SK.Run(() =>
        {
            var deltaTime = Time.Stepf;
            foreach (var system in Systems)
            {
                if (system.IsEnabled)
                {
                    system.Update(deltaTime);
                }
            }
        });
        Cleanup();
    }

    static void Cleanup()
    {
        Systems.ForEach(system => system.Dispose());
        World.Dispose();
        SK.Shutdown();
    }
}