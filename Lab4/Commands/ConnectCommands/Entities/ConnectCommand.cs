using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands.Entities;

public class ConnectCommand : ICommand
{
    private readonly string _absolutePath;
    private readonly string _mode;

    public ConnectCommand(string absolutePath, string mode)
    {
        _absolutePath = absolutePath;
        _mode = mode;
    }

    public CommandExecutionResult Execute(Context context)
    {
        IFileSystem fileSystem = context.FileSystem;
        if (!fileSystem.DirectoryExists(_absolutePath))
            return new CommandExecutionResult.DirectoryWasNotFound("Directory was not found");
        context.Connect(_absolutePath, _mode);

        return new CommandExecutionResult.Success();
    }
}