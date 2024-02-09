namespace Nazar.Components;

public struct TextComponent
{
    public string Content;
    public Matrix Transform;
    public TextFit Fit;
    public Vec2 Size;

    public void Draw()
    {
        Text.Add(Content, Transform, Fit, Size);
    }
}
