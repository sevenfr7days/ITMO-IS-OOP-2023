using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands.Entities;

public class DisconnectCommand : ICommand
{
    public CommandExecutionResult Execute(Context context)
    {
        context.Disconnect();
        return new CommandExecutionResult.Success();
    }
}