using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CopyFileCommands.Entities;

public class CopyFileCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public CopyFileCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandExecutionResult Execute(Context context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (!fileSystem.IsPathRooted(_sourcePath))
        {
            _sourcePath = fileSystem.Combine(context.CurrentAbsolutePath, _sourcePath);
        }

        if (!fileSystem.IsPathRooted(_destinationPath))
        {
            _destinationPath = fileSystem.Combine(context.CurrentAbsolutePath, _destinationPath);
        }

        return fileSystem.CopyFile(_sourcePath, _destinationPath);
    }
}