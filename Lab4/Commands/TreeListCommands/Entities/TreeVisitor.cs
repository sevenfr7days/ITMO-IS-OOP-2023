using System;
using Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreeConfigs.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Entities;

public class TreeVisitor : ITreeVisitor
{
    public void VisitDirectory(string path, int depth, Context context, string indent)
    {
        DirectoryTreeConfig config = context.DirectoryTreeConfig;
        IFileSystem fileSystem = context.FileSystem;
        string? directoryName = fileSystem.GetFileName(path);
        if (directoryName is not null)
        {
            Console.WriteLine($"{indent}{config.DirectorySymbol} {directoryName}");
        }
    }

    public void VisitFile(string path, Context context, string indent)
    {
        DirectoryTreeConfig config = context.DirectoryTreeConfig;
        IFileSystem fileSystem = context.FileSystem;
        string? fileName = fileSystem.GetFileName(path);
        if (fileName is not null)
        {
            Console.WriteLine($"{indent}{config.FileSymbol} {fileName}");
        }
    }
}