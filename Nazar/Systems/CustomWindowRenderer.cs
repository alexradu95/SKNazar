using Nazar.Components;
using StereoKit;

namespace Nazar.Systems;

public class CustomWindowRenderer : BaseSystem<float>
{
    public CustomWindowRenderer(World world) : base(world) { }

    public override void Update(float state)
    {
        var customWindowEntities = World.GetEntities().With<CustomWindowComponent>().AsSet();

        foreach (ref readonly var entity in customWindowEntities.GetEntities())
        {
            ref var customWindow = ref entity.Get<CustomWindowComponent>();
            UI.HandleBegin("CustomWindow", ref customWindow.Pose, customWindow.Model.Bounds);
            customWindow.Model.Draw(Matrix.Identity);
            UI.LayoutArea(Vec3.Zero, customWindow.LayoutSize * U.cm);
            // ... UI elements for the custom window ...
            UI.HandleEnd();
        }
    }
}
