namespace Nazar.Components;

public struct SpatialComponent
{
    public bool IsVisible;
    public TransformComponent Transform;

    public SpatialComponent(bool isVisible, TransformComponent transform)
    {
        IsVisible = isVisible;
        Transform = transform;
    }
}
