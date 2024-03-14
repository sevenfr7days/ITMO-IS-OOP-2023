using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DeleteFileCommands.Entities;

public class DeleteFileCommand : ICommand
{
    private string _path;

    public DeleteFileCommand(string path)
    {
        _path = path;
    }

    public CommandExecutionResult Execute(Context context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (fileSystem.IsPathRooted(_path))
        {
            _path = fileSystem.Combine(context.CurrentAbsolutePath, _path);
        }

        return fileSystem.DeleteFile(_path);
    }
}