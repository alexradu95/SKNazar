using System;
using System.Collections.Generic;
using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components.Animations;
using Nazar.Components.Behaviours;
using Nazar.Components.Properties;
using Nazar.Components.UIElements;
using Nazar.Messages;
using Nazar.Systems;
using Nazar.Systems.Animations;
using Nazar.Systems.EntitySystems;
using Nazar.Systems.Interactions;
using StereoKit;
using World = DefaultEcs.World;

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
        Systems.Add(new AnimationRotationOnAxisSystem(World));
        Systems.Add(new MoveableEntitySystem(World));
        Systems.Add(new ButtonInteractionSystem(World));
        Systems.Add(new SimpleTextWindowDrawSystem(World));
        Systems.Add(new UpdateTextOnButtonPressSystem(World, CreateMovableTextWindow()));
    }

    static void CreateEntities()
    {
        CreateRotatingCube();
        CreateButton();
    }

    static void CreateRotatingCube()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new ModelComponent { Value = Model.FromMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f), Default.MaterialUI) });
        entity.Set(new AnimationAxisComponent { Speed = 30f, Axis = Vec3.Up });
    }

    static Entity CreateMovableTextWindow()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(-0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new MoveableComponent());
        entity.Set(new TextContentsComponent { TextContents = "test" });
        return entity;
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