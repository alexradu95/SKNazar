using Nazar.Messaging.Components;
using ButtonComponent = Nazar.Rendering.Components.ButtonComponent;

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
                new HandMenuItem("Button", null, () =>
                {
                    var entity = world.CreateEntity();
                    entity.Set(new ButtonComponent { IsPressed = false });
                    entity.Set(new TextComponent { Content = "New Button" });
                    entity.Set(new TransformComponent { Position = new Pose(0.0f, 0, -0.5f, Quat.Identity), Scale = Vec3.One});
                    entity.Set(new SubscriberComponent { EventName = "ButtonPressed" });
                    entity.Set(new IdComponent(Guid.NewGuid()));
                }),
                new HandMenuItem("Text Window", null, () =>
                {
                    var entity = world.CreateEntity();
                    entity.Set(new WindowComponent { Size = Vec2.Zero, ShowHeader = true });
                    entity.Set(new TransformComponent { Position = new Pose(-0.3f, 0, -0.5f, Quat.Identity), Scale = Vec3.One });
                    entity.Set(new SubscriberComponent { EventName = "ButtonPressed" });
                    entity.Set(new IdComponent(Guid.NewGuid()));
                }),
                new HandMenuItem("Mesh", null, () =>
                {
                    var entity = world.CreateEntity();
                    entity.Set(new MeshComponent { Mesh = Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f) });
                    entity.Set(new TransformComponent { Position = new Pose(0.3f, 0, -0.5f, Quat.Identity), Scale = Vec3.One });
                    entity.Set(new IdComponent(Guid.NewGuid()));
                }),
                new HandMenuItem("Model", null, () =>
                {
                    var entity = world.CreateEntity();
                    entity.Set(new ModelComponent { Model = Model.FromFile("StereoKit.glb") });
                    entity.Set(new TransformComponent { Position = new Pose(0.6f, 0, -0.5f, Quat.Identity), Scale = Vec3.One });
                    entity.Set(new IdComponent(Guid.NewGuid()));
                }),
                new HandMenuItem("Text", null, () =>
                {
                    var entity = world.CreateEntity();
                    entity.Set(new TextComponent { Content = "New Text" });
                    entity.Set(new TransformComponent { Position = new Pose(-0.9f, 0, -0.5f, Quat.Identity), Scale = Vec3.One });
                    entity.Set(new IdComponent(Guid.NewGuid()));
                }),
                new HandMenuItem("Line", null, () =>
                {
                    var entity = world.CreateEntity();
                    entity.Set(new LineComponent
                        { Start = new Vec3(-1.2f, 0, -0.5f), End = new Vec3(-1.2f, 0.1f, -0.5f) });
                    entity.Set(new TransformComponent { Position = new Pose(-1.2f, 0, -0.5f, Quat.Identity), Scale = Vec3.One });
                    entity.Set(new IdComponent(Guid.NewGuid()));
                }),
                new HandMenuItem("Back", null, null, HandMenuAction.Back))));

        SK.AddStepper(handMenu);
    }
}
