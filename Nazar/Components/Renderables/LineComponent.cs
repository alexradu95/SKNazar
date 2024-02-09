namespace Nazar.Components;

public struct LineComponent
{
    public Vec3 Start;
    public Vec3 End;
    public Color Color;
    public float Thickness;

    public void Draw()
    {
        Lines.Add(Start, End, Color, Thickness);
    }
}
