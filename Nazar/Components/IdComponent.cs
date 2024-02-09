namespace Nazar.Components;

public struct IdComponent
{
    public Guid Id { get; private set; }

    public IdComponent(Guid id)
    {
        Id = id;
    }

    public static IdComponent NewId()
    {
        return new IdComponent(Guid.NewGuid());
    }
}
