namespace Nazar.Components;

public struct TextComponent
{
    public string Content;
    public Matrix Transform;

    public void Draw()
    {
        Text.Add(Content, Transform);
    }
}
