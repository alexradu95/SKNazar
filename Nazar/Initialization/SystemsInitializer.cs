using Nazar.Messaging.Systems;
using Nazar.Rendering.Systems;

namespace Nazar.Initialization;

public static class SystemsInitializer
{
    public static void InitializeSystems(World world, List<ISystem<float>> systems)
    {
        systems.Add(new ButtonRenderSystem(world));
        systems.Add(new ButtonInteractionSystem(world));
        systems.Add(new ButtonPressedMessageHandler(world));
        systems.Add(new EntityDebugSystem(world));
        InitializeRenderingSystems(world, systems);
    }

    public static void InitializeRenderingSystems(World world, List<ISystem<float>> renderingSystems)
    {
        renderingSystems.Add(new MeshRenderSystem(world));
        renderingSystems.Add(new WindowRenderSystem(world));
        renderingSystems.Add(new ModelRenderSystem(world));
        renderingSystems.Add(new TextRenderSystem(world));
        renderingSystems.Add(new LineRenderSystem(world));
    }
}
