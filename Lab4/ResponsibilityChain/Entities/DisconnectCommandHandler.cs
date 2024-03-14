using Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

public class DisconnectCommandHandler : ChainLinkBase
{
    private const string DisconnectCommandKeyWord = "DISCONNECT";
    private const int ExpectedDisconnectCommandIndex = 0;

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 1 || request.Components[ExpectedDisconnectCommandIndex].Value.ToUpperInvariant() != DisconnectCommandKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        return new HandleResult.Success(new DisconnectCommand());
    }
}