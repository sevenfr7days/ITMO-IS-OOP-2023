using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShow.Entities;

public class ConsoleShowFile : IShowFile
{
    public void ShowFile(string content)
    {
        Console.WriteLine(content);
    }
}