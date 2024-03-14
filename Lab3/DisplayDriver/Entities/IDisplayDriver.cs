using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Entities;

public interface IDisplayDriver
{
    void Clear();
    void ChangeColor(Color color);
    void WriteMessage(string message);
}