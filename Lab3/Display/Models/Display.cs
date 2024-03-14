using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Display.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.Models;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ChangeTextColor(Color color)
    {
        _displayDriver.ChangeColor(color);
    }

    public void WriteMessage(string message)
    {
        _displayDriver.Clear();
        _displayDriver.WriteMessage(message);
    }
}