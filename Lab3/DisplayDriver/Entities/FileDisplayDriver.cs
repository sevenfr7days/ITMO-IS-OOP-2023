using System;
using System.Drawing;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Entities;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;

    public FileDisplayDriver(string filePath)
    {
        _filePath = filePath;
    }

    public void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void ChangeColor(Color color)
    {
    }

    public void WriteMessage(string message)
    {
        File.AppendAllText(_filePath, message + Environment.NewLine);
    }
}