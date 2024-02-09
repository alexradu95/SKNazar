namespace Nazar.Rendering.Components;

public struct LineComponent
{
    public Vec3 Start;
    public Vec3 End;

    public void Draw()
    {
        Lines.Add(Start, End, Color32.Black, 1);
    }
}
