using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListShows;

public class ConsoleShowTree : IShowTree
{
    public void ShowTreePart(string content)
    {
        Console.WriteLine(content);
    }
}