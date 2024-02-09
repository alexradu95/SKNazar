using Nazar.Factories;
using StereoKit.Framework;

namespace Nazar.Initialization;

public static class HandMenuInitializer
{
    public static void SetupHandMenu(World world)
    {
        var handMenu = new HandMenuRadial(
            new HandRadialLayer("Create Entities",
                new HandMenuItem("Create Button", null, () => CreateButtonEntity(world)),
                new HandMenuItem("Create Text Window", null, () => CreateTextWindowEntity(world)),
                new HandMenuItem("Create Mesh", null, () => CreateMeshEntity(world)),
                new HandMenuItem("Create Model", null, () => CreateModelEntity(world)),
                new HandMenuItem("Create Text", null, () => CreateTextEntity(world)),
                new HandMenuItem("Create Line", null, () => CreateLineEntity(world)),
                new HandMenuItem("Close", null, null)));
        SK.AddStepper(handMenu);
    }

    private static void CreateButtonEntity(World world)
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

    private static void CreateMeshEntity(World world)
    {
        world.CreateEntity().WithMesh(Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f))
            .WithTransform(new Pose(0.3f, 0, -0.5f, Quat.Identity));
    }

    private static void CreateModelEntity(World world)
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