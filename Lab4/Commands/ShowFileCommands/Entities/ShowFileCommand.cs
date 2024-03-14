using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands.Entities;

public class ShowFileCommand : ICommand
{
    private const string ConsoleModeKeyWord = "CONSOLE";
    private readonly string? _mode;
    private string _path;

    public ShowFileCommand(string path, string? mode)
    {
        _path = path;
        _mode = mode;
    }

    public CommandExecutionResult Execute(Context context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (_mode is not null && _mode.Equals(ConsoleModeKeyWord, StringComparison.OrdinalIgnoreCase))
        {
            return new CommandExecutionResult.UnknownMood("Unknown show file mode");
        }

        if (!fileSystem.IsPathRooted(_path))
        {
            _path = fileSystem.Combine(context.CurrentAbsolutePath, _path);
        }

        if (fileSystem.FileExists(_path))
        {
            string content = fileSystem.ReadFile(_path);
            context.ShowFileStrategy.ShowFile(content);
            return new CommandExecutionResult.Success();
        }

        return new CommandExecutionResult.FileWasNotFound("File was not found");
    }
}