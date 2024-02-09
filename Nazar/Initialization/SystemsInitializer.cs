using Nazar.MessageHandlers;

namespace Nazar.Initialization;

public static class SystemsInitializer
{
    public static void InitializeSystems(World world, List<ISystem<float>> systems, List<ISystem<float>> renderingSystems)
    {
        systems.Add(new ButtonRenderer(world));
        systems.Add(new ButtonInteractionSystem(world));
        systems.Add(new ButtonPressedMessageHandler(world));
        InitializeRenderingSystems(world, renderingSystems);
    }

    public static void InitializeRenderingSystems(World world, List<ISystem<float>> renderingSystems)
    {
        renderingSystems.Add(new MeshRenderSystem(world));
        renderingSystems.Add(new ModelRenderSystem(world));
        renderingSystems.Add(new TextRenderSystem(world));
        renderingSystems.Add(new LineRenderSystem(world));
    }
}
