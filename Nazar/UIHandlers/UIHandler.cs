using Nazar.Components;

namespace Nazar.UIHandlers;

public static class UIHandler
{
    public static void DrawButton(ref ButtonComponent button, ref PositionComponent position, ref TextContentsComponent textContent)
    {
        UI.WindowBegin(textContent.TextContents + "Window", ref position.Value, new Vec2(20, 0) * U.cm);
        button.IsPressed = UI.Button(textContent.TextContents);
        UI.WindowEnd();
    }

    public static void DrawTextWindow(ref TextContentsComponent textContent, ref PositionComponent position)
    {
        UI.WindowBegin(textContent.TextContents + "Window", ref position.Value, new Vec2(20, 0) * U.cm);
        UI.Label(textContent.TextContents);
        UI.WindowEnd();
    }
}