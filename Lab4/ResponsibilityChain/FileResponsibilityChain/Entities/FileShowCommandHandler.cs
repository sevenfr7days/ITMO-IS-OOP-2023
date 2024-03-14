using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.FileResponsibilityChain.Entities;

public class FileShowCommandHandler : ChainLinkBase
{
    private const string ShowKeyWord = "SHOW";
    private const string ModeFlagKeyWord = "-m";
    private const int ExpectedShowCommandIndex = 1;
    private const int ExpectedPathIndex = 2;
    private string? _path;
    private string? _potentialMode;
    private string _mode = "CONSOLE";

    public override HandleResult Handle(Request request)
    {
        if (request.Components.Count < 3 || request.Components[ExpectedShowCommandIndex].Value.ToUpperInvariant() != ShowKeyWord)
        {
            return Next is not null ? Next.Handle(request) : new HandleResult.Fail();
        }

        _path = request.Components[ExpectedPathIndex].Value;

        int modeFlagIndex = request.Components.IndexOf(new RequestComponent(ModeFlagKeyWord));

        // try to find mode flag
        if (modeFlagIndex > 0)
        {
            if (modeFlagIndex + 1 >= request.Components.Count)
            {
                return new HandleResult.Fail();
            }

            // validation of input mode flag
            _potentialMode = request.Components[modeFlagIndex + 1].Value;
            _potentialMode = _potentialMode.ToUpperInvariant();

            if (Enum.IsDefined(typeof(FileShowMode), _potentialMode))
            {
                _mode = _potentialMode;
            }
            else
            {
                return new HandleResult.Fail();
            }
        }

        return new HandleResult.Success(new ShowFileCommand(_path, _mode));
    }
}