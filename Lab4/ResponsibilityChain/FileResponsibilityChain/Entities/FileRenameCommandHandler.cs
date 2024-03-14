using Itmo.ObjectOrientedProgramming.Lab4.Commands.RenameFileCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.FileResponsibilityChain.Entities;

public class FileRenameCommandHandler : ChainLinkBase
{
    private const string RenameKeyWord = "RENAME";
    private const int ExpectedRenameCommandIndex = 1;
    private const int ExpectedPathIndex = 2;
    private const int ExpectedNameIndex = 3;
    private string? _path;
    private string? _name;

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 4 || request.Components[ExpectedRenameCommandIndex].Value.ToUpperInvariant() != RenameKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        _path = request.Components[ExpectedPathIndex].Value;
        _name = request.Components[ExpectedNameIndex].Value;
        return new HandleResult.Success(new RenameFileCommand(_path, _name));
    }
}