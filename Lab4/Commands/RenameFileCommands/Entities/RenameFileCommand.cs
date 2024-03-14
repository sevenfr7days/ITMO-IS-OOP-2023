using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.RenameFileCommands.Entities;

public class RenameFileCommand : ICommand
{
    private readonly string _name;
    private string _path;

    public RenameFileCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandExecutionResult Execute(Context context)
    {
        IFileSystem fileSystem = context.FileSystem;
        if (!fileSystem.IsPathRooted(_path))
        {
            _path = fileSystem.Combine(context.CurrentAbsolutePath, _path);
        }

        return fileSystem.RenameFile(_path, _name);
    }
}