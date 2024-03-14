using Itmo.ObjectOrientedProgramming.Lab4.Commands.DeleteFileCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.FileResponsibilityChain.Entities;

public class FileDeleteCommandHandler : ChainLinkBase
{
    private const string DeleteKeyWord = "DELETE";
    private const int ExpectedDeleteCommandIndex = 1;
    private const int ExpectedPathIndex = 2;

    private string? _path;

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 3 || request.Components[ExpectedDeleteCommandIndex].Value.ToUpperInvariant() != DeleteKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        _path = request.Components[ExpectedPathIndex].Value;
        return new HandleResult.Success(new DeleteFileCommand(_path));
    }
}