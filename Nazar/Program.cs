using System;
using DefaultEcs;
using Nazar.Components;
using Nazar.Systems;
using StereoKit;
using System.Collections.Generic;
using System.Linq;
using DefaultEcs.System;
using Nazar.Messages;
using World = DefaultEcs.World;

class Program
{
    private static readonly World World = new World();
    private static readonly List<ISystem<float>> Systems = new List<ISystem<float>>();
    private static Entity entityTwo; // Keep a reference to entityTwo for system initialization

    static void Main(string[] args)
    {
        if (TryInitializeNazar())
        {
            RunApplication();
        }
    }

    static bool TryInitializeNazar()
    {
        if (!InitializeStereoKit()) return false;
        CreateEntities();
        InitializeEcs(); // Initialize ECS after entities to pass entityTwo to the system
        return true;
    }

    static bool InitializeStereoKit()
    {
        return SK.Initialize(CreateStereoKitSettings());
    }

    static SKSettings CreateStereoKitSettings()
    {
        return new SKSettings
        {
            appName = "Nazar",
            assetsFolder = "Assets",
        };
    }

    static void InitializeEcs()
    {
        // Initialize systems here
        Systems.Add(new ModelsDrawSystem(World));
        Systems.Add(new AnimationRotationOnAxisSystem(World));
        Systems.Add(new MoveableEntitySystem(World));
        Systems.Add(new ButtonInteractionSystem(World));
        Systems.Add(new SimpleTextWindowDrawSystem(World));
        // Initialize UpdateTextOnButtonPressSystem with entityTwo
        Systems.Add(new UpdateTextOnButtonPressSystem(World, entityTwo));
    }

    static void CreateEntities()
    {
        CreateEntityOne();
        entityTwo = CreateEntityTwo(); // Assign the returned entity to entityTwo
        CreateButtonEntity();
    }
    
    static void CreateEntityOne()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new ModelComponent { Value = Model.FromMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f), Default.MaterialUI) });
        entity.Set(new AnimationAxisComponent { Speed = 30f, Axis = Vec3.Up });
    } 
    
    // Adjust CreateEntityTwo to return an Entity
    static Entity CreateEntityTwo()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(-0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new MoveableComponent());
        entity.Set(new TextContentsComponent() { TextContents = "test"});
        return entity; // Return the created entity
    }

    static void CreateButtonEntity()
    {
        var buttonEntity = World.CreateEntity();
        buttonEntity.Set(new ButtonComponent { Label = "Press Me!", IsPressed = false});
        buttonEntity.Set(new IdComponent() {Id = Guid.NewGuid()});
    }

    static void RunApplication()
    {
        SK.Run(() =>
        {
            var deltaTime = Time.Stepf;
            foreach (var system in Systems.Where(system => system.IsEnabled))
            {
                system.Update(deltaTime);
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
