using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

public class ConnectCommandHandler : ChainLinkBase
{
    private const string ConnectCommandKeyWord = "CONNECT";
    private const string ModeFlagKeyWord = "-m";
    private const int ExpectedConnectCommandIndex = 0;
    private const int ExpectedPathIndex = 1;
    private string _mode = "local";
    private string? _address;

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 2 || request.Components[ExpectedConnectCommandIndex].Value.ToUpperInvariant() != ConnectCommandKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        _address = request.Components[ExpectedPathIndex].Value;

        int modeFlagIndex = request.Components.IndexOf(new RequestComponent(ModeFlagKeyWord));
        if (modeFlagIndex > 0)
        {
            if (modeFlagIndex + 1 < request.Components.Count)
            {
                _mode = request.Components[modeFlagIndex + 1].Value;
            }
            else
            {
                return new HandleResult.Fail();
            }
        }

        return new HandleResult.Success(new ConnectCommand(_address, _mode));
    }
}