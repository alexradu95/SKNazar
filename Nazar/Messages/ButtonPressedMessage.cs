namespace Nazar.Messages;

public class ButtonPressedMessage
{
    public string ButtonId { get; }

    public ButtonPressedMessage(string buttonId)
    {
        ButtonId = buttonId;
    }
}
