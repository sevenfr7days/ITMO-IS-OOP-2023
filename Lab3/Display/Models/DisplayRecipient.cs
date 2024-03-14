using Itmo.ObjectOrientedProgramming.Lab3.Display.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.Models;

public class DisplayRecipient : IRecipient
{
    private readonly IDisplay _display;

    public DisplayRecipient(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(IMessage message)
    {
        _display.WriteMessage(message.ConvertMessageToString());
    }
}