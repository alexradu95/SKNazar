using Nazar.Execution;
using Nazar.Initialization;

namespace Nazar;

internal class Program
{
    private static void Main(string[] args)
    {
        if (ApplicationInitializer.Initialize(out var world, out var systems))
            ApplicationRunner.Run(world, systems);
    }
}