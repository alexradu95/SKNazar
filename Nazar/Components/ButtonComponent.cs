namespace Nazar.Components;

using System;

public struct ButtonComponent
{
    public string Label;
    public Action OnPressed;

    public void PressButton()
    {
        OnPressed?.Invoke();
    }
}

/// <summary>
/// Represents a button component with a label.
/// </summary>