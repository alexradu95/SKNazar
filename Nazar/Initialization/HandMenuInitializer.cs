using Nazar.Factories;
using StereoKit.Framework;

namespace Nazar.Initialization;

public static class HandMenuInitializer
{

 public static void SetupHandMenu(World world)
{
        var handMenu = SK.AddStepper(new HandMenuRadial(
            new HandRadialLayer("Root",
                new HandMenuItem("Create", null, null, "Create"),
                new HandMenuItem("Config", null, () => world.Get<EntityDebugSystem>().ToggleActive())),
            new HandRadialLayer("Create",
                new HandMenuItem("Button", null, () => CreateButtonEntity(world)),
                new HandMenuItem("Text Window", null, () => CreateTextWindowEntity(world)),
                new HandMenuItem("Mesh", null, () => CreateMeshEntity(world)),
                new HandMenuItem("Model", null, () => CreateModelEntity(world)),
                new HandMenuItem("Text", null, () => CreateTextEntity(world)),
                new HandMenuItem("Line", null, () => CreateLineEntity(world)),
                new HandMenuItem("Back", null, null, HandMenuAction.Back))));

        SK.AddStepper(handMenu);
}
    static void CreateButtonEntity(World world)
    {
        world.CreateEntity().WithButton("New Button")
            .WithTransform(new Pose(0.0f, 0, -0.5f, Quat.Identity))
            .WithSubscriber("ButtonPressed");
    }

    private static void CreateTextWindowEntity(World world)
    {
        world.CreateEntity().WithTextWindow()
            .WithTransform(new Pose(-0.3f, 0, -0.5f, Quat.Identity))
            .WithSubscriber("ButtonPressed");
    }

    static void CreateMeshEntity(World world)
    {
        world.CreateEntity().WithMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f))
            .WithTransform(new Pose(0.3f, 0, -0.5f, Quat.Identity));
    }

    static void CreateModelEntity(World world)
    {
        world.CreateEntity().WithModel(Model.FromFile("StereoKit.glb"))
            .WithTransform(new Pose(0.6f, 0, -0.5f, Quat.Identity));
    }

    private static void CreateTextEntity(World world)
    {
        world.CreateEntity().WithText("New Text")
            .WithTransform(new Pose(-0.9f, 0, -0.5f, Quat.Identity));
    }

    private static void CreateLineEntity(World world)
    {
        world.CreateEntity().WithLine(new Vec3(-1.2f, 0, -0.5f), new Vec3(-1.2f, 0.1f, -0.5f));
    }
}