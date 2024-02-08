using StereoKit;
using System.Collections.Generic;

namespace Nazar.Execution;

public static class ApplicationRunner
{
    public static void Run(World world, List<ISystem<float>> systems)
    {
        SK.Run(() =>
        {
            var deltaTime = Time.Stepf;
            foreach (var system in systems)
                if (system.IsEnabled)
                    system.Update(deltaTime);
        });
        Cleanup(world);
    }

    private static void Cleanup(World world)
    {
        world.Dispose();
        SK.Shutdown();
    }
}
