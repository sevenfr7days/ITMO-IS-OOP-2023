using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands.Entities;

public class TreeGotoCommand : ICommand
{
    private string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
    }

    public CommandExecutionResult Execute(Context context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (!fileSystem.IsPathRooted(_path))
        {
            _path = fileSystem.Combine(context.CurrentAbsolutePath, _path);
        }

        if (fileSystem.DirectoryExists(_path))
        {
            context.GotoAction(_path);
            return new CommandExecutionResult.Success();
        }

        return new CommandExecutionResult.SubdirectoryWasNotFound("Subdirectory was not found");
    }
}