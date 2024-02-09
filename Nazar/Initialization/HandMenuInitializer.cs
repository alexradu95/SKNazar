using Nazar.Factories;
using StereoKit.Framework;

namespace Nazar.Initialization;

public static class HandMenuInitializer
{
    public static void SetupHandMenu(World world)
    {
        HandMenuRadial handMenu = new HandMenuRadial(
            new HandRadialLayer("Create Entities",
                new HandMenuItem("Create Button", null, () => CreateButtonEntity(world)),
                new HandMenuItem("Create Text Window", null, () => CreateTextWindowEntity(world)),
                new HandMenuItem("Create Mesh", null, () => CreateMeshEntity(world)),
                new HandMenuItem("Create Model", null, () => CreateModelEntity(world)),
                new HandMenuItem("Create Text", null, () => CreateTextEntity(world)),
                new HandMenuItem("Create Line", null, () => CreateLineEntity(world)),
                new HandMenuItem("Close", null, null, HandMenuAction.Close)));
        SK.AddStepper(handMenu);
    }

    // The entity creation methods will be moved here as well.
    // ...
}
