namespace Nazar.Messages;

public struct IdComponent
{
    public Guid Id; // Unique identifier for the button
}

public struct ButtonPressedMessage
{
    public Guid ButtonEntityId;
}