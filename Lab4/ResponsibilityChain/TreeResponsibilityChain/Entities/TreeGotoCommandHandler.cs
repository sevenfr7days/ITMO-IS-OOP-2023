using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.TreeResponsibilityChain.Entities;

public class TreeGotoCommandHandler : ChainLinkBase
{
    private const string GotoKeyWord = "GOTO";
    private string? _path;

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 3 || request.Components[1].Value.ToUpperInvariant() != GotoKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        _path = request.Components[2].Value;

        return new HandleResult.Success(new TreeGotoCommand(_path));
    }
}