namespace Nazar.Components;

public struct TextComponent
{
    public string Content;
    public Matrix Transform;
    public TextFit Fit;
    public Vec2 Size;
    public TextStyle Style;
    public Color Color;
    public TextAlign Position;
    public TextAlign Align;
    public float OffX;
    public float OffY;
    public float OffZ;

    public void Draw()
    {
        Text.Add(Content, Transform, Style, Color, Position, Align, OffX, OffY, OffZ);
    }
}
