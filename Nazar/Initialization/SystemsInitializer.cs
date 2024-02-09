using Nazar.MessageHandlers;

namespace Nazar.Initialization;

public static class SystemsInitializer
{
    public static void InitializeSystems(World world, List<ISystem<float>> systems)
    {
        systems.Add(new ButtonDrawSystem(world));
        systems.Add(new ButtonInteractionSystem(world));
        systems.Add(new ButtonPressedMessageHandler(world));
        systems.Add(new TextWindowDrawSystem(world));
    }
}