namespace Nazar.Components;

using System;

public struct ButtonComponent
{
    public string Label;
    public bool IsPressed;
    public Action OnPressed; // This action will be invoked by the ButtonInteractionSystem
}
