using Itmo.ObjectOrientedProgramming.Lab4.Commands.CopyFileCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.FileResponsibilityChain.Entities;

public class FileCopyCommandHandler : ChainLinkBase
{
    private const string CopyKeyWord = "COPY";
    private const int ExpectedCopyCommandIndex = 1;
    private const int ExpectedSourcePathIndex = 2;
    private const int ExpectedDestinationPathIndex = 3;

    private string? _sourcePath;
    private string? _destinationPath;

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 4 || request.Components[ExpectedCopyCommandIndex].Value.ToUpperInvariant() != CopyKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        _sourcePath = request.Components[ExpectedSourcePathIndex].Value;
        _destinationPath = request.Components[ExpectedDestinationPathIndex].Value;
        return new HandleResult.Success(new CopyFileCommand(_sourcePath, _destinationPath));
    }
}