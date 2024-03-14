using System.Drawing;
using static Crayon.Output;
using Console = System.Console;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Entities;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _currentColor = Color.White;

    public void Clear()
    {
        Console.Clear();
    }

    public void ChangeColor(Color color)
    {
        _currentColor = color;
    }

    public void WriteMessage(string message)
    {
        string coloredText = Rgb(_currentColor.R, _currentColor.G, _currentColor.B).Text(message);
        Console.WriteLine(coloredText);
        Console.ResetColor();
    }
}