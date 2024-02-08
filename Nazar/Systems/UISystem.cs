using DefaultEcs;
using DefaultEcs.System;
using Nazar.Components;
using StereoKit;
using World = DefaultEcs.World;

namespace Nazar.Systems;

public class UISystem : ISystem<float> {
    private readonly World _world;

    public UISystem(World world) {
        _world = world;
    }

    public bool IsEnabled { get; set; } = true;

    public void Update(float state) {
        var uiSet = _world.GetEntities().With<ButtonComponent>().AsSet();
        foreach (ref readonly Entity entity in uiSet.GetEntities()) {
            ref var ui = ref entity.Get<ButtonComponent>();

            if (UI.Button(ui.Label)) {
                ui.OnClick?.Invoke();
            }
        }
    }

    public void Dispose() { }
}