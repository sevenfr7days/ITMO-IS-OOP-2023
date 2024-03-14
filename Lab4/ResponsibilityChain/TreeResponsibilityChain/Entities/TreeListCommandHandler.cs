using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.TreeResponsibilityChain.Entities;

public class TreeListCommandHandler : ChainLinkBase
{
    private const string ListKeyWord = "LIST";
    private const string DepthFlagKeyWord = "-d";
    private int _depth = 1;

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 2 || request.Components[1].Value.ToUpperInvariant() != ListKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        int depthFlagIndex = request.Components.IndexOf(new RequestComponent(DepthFlagKeyWord));

        if (depthFlagIndex > 0)
        {
            if (depthFlagIndex + 1 > request.Components.Count)
            {
                return new HandleResult.Fail();
            }

            string potentialDepthArgument = request.Components[depthFlagIndex + 1].Value;
            if (int.TryParse(potentialDepthArgument, out int result))
            {
                _depth = result;
            }
            else
            {
                return new HandleResult.Fail();
            }
        }

        return new HandleResult.Success(new TreeListCommand(_depth, new TreeVisitor()));
    }
}