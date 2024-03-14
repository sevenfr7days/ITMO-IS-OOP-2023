using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;

public interface ICommand
{
    public CommandExecutionResult Execute(Context context);
}