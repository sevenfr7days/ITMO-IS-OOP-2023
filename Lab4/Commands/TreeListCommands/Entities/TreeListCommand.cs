using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Entities;

public class TreeListCommand : ICommand
{
    private readonly int _maxDepth;
    private ITreeVisitor _treeVisitor;

    public TreeListCommand(int maxDepth, ITreeVisitor treeVisitor)
    {
        _maxDepth = maxDepth;
        _treeVisitor = treeVisitor;
    }

    public CommandExecutionResult Execute(Context context)
    {
        PrintDirectoryTree(context.CurrentAbsolutePath, _maxDepth, context, _treeVisitor);
        return new CommandExecutionResult.Success();
    }

    private static void PrintDirectoryTree(string directoryPath, int maxDepth, Context context, ITreeVisitor visitor, int currentDepth = 0, string indent = "", bool isLast = true)
    {
        IFileSystem fileSystem = context.FileSystem;
        if (currentDepth > maxDepth) return;

        string fullPath = fileSystem.GetFullPath(directoryPath);
        visitor.VisitDirectory(fullPath, currentDepth, context, indent);

        if (currentDepth == maxDepth) return;

        string newIndent = indent + (isLast ? context.DirectoryTreeConfig.Indent : context.DirectoryTreeConfig.Branch);

        IList<string> subDirectories = fileSystem.GetDirectories(directoryPath);
        IList<string> files = fileSystem.GetFiles(directoryPath);

        for (int i = 0; i < subDirectories.Count; i++)
        {
            PrintDirectoryTree(subDirectories[i], maxDepth, context, visitor, currentDepth + 1, newIndent, i == subDirectories.Count - 1 && files.Count == 0);
        }

        if (currentDepth >= maxDepth) return;
        foreach (string file in files)
        {
            visitor.VisitFile(file, context, newIndent);
        }
    }
}