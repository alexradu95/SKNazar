using DefaultEcs;
using Nazar.Components;
using Nazar.Systems;
using StereoKit;
using System.Collections.Generic;
using DefaultEcs.System;
using World = DefaultEcs.World;

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
        if (InitializeStereoKit())
        {
            InitializeEcs();
            CreateEntities();
            return true;
        }
        return false;
    }

    static bool InitializeStereoKit()
    {
        return SK.Initialize(new SKSettings
        {
            appName = "Nazar",
            assetsFolder = "Assets",
        });
    }

    static void InitializeEcs()
    {
        // Initialize and store your systems here
        Systems.Add(new HandleSystem(World));
        Systems.Add(new DrawSystem(World));
        Systems.Add(new AnimationSystem(World));
        Systems.Add(new InteractionSystem(World));
        Systems.Add(new UISystem(World));
    }

    static void CreateEntities()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new ModelComponent { Value = Model.FromMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f), Default.MaterialUI) });
        entity.Set(new AnimationComponent { Speed = 30f, Axis = Vec3.Up });

        // Correct entity references for entityTwo and buttonEntity
        var entityTwo = World.CreateEntity();
        entityTwo.Set(new PoseComponent { Value = new Pose(-0.2f, 0, -0.5f, Quat.Identity) });
        entityTwo.Set(new ModelComponent { Value = Model.FromMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f), Default.MaterialUnlit) });
        entityTwo.Set(new InteractableComponent());

        var buttonEntity = World.CreateEntity();
        buttonEntity.Set(new ButtonComponent { Label = "Press Me!", OnClick = () => System.Console.WriteLine("Button Pressed!") });
    }

    static void RunApplication()
    {
        // Manually run each system in the update loop
        SK.Run(() =>
        {
            float deltaTime = Time.Stepf;
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
        // Dispose systems if necessary
        foreach (var system in Systems)
        {
            system.Dispose();
        }
        World.Dispose();
        SK.Shutdown();
    }
}
