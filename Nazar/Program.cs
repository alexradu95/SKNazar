using System.Linq;
﻿using System.Linq;
using Nazar.Components;

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
        Systems.Add(new SimpleTextWindowDrawSystem(World));
    }

    private static void CreateEntities()
    {
        CreateButton();
        CreateMovableTextWindow();
    }

    // Create a moveable window that has an input a string value
    // Each input/output will contain an unique_id, it's name, it's dataType and the entity is it assigned to
    private static void CreateMovableTextWindow()
    {
        var entity = World.CreateEntity();
        entity.Set(new PoseComponent { Value = new Pose(-0.2f, 0, -0.5f, Quat.Identity) });
        entity.Set(new TextContentsComponent { TextContents = "test" });
        var input = new InputComponent
        {
            UniqueId = Guid.NewGuid(),
        };
        entity.Set(input);
    }
    
    private static void CreateButton()
    {
        var buttonEntity = World.CreateEntity();
        buttonEntity.Set(new ButtonComponent { Label = "Press Me!" });
        buttonEntity.Set(new PoseComponent { Value = new Pose(0.2f, 0, -0.5f, Quat.Identity) });
        var output = new OutputComponent
        {
            UniqueId = Guid.NewGuid(),
        };
        buttonEntity.Set(output);
        var movableTextWindowEntities = World.GetEntities().With<InputComponent>().With<TextContentsComponent>().AsSet().GetEntities();
        if (movableTextWindowEntities.Length > 0)
        {
            var movableTextWindowEntity = movableTextWindowEntities[0];
            movableTextWindowEntity.Set(new AssociatedEntityComponent() { EntityId = output.UniqueId });
        }
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