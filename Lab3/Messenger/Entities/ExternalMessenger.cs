using System;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger.Entities;

public class ExternalMessenger : IExternalMessenger
{
    public void WriteMessage(string message)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Messenger: ");
        stringBuilder.Append(message);
        Console.WriteLine(stringBuilder.ToString());
    }
}