namespace Nazar.Components;

using System;

public struct ButtonComponent
{
    public string Label;
    public Action OnPressed; // This action will be invoked by the ButtonInteractionSystem
}

/// <summary>
/// Represents a button component with a label.
/// </summary>
