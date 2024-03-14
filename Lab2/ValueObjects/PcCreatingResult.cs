using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class PcCreatingResult
{
    private IReadOnlyCollection<SolutionMessage> _messages;

    public PcCreatingResult(IReadOnlyCollection<SolutionMessage> messages)
    {
        _messages = messages;
    }

    public Results GetPcCreatingResult()
    {
        var stringBuilder = new StringBuilder();
        foreach (SolutionMessage message in _messages)
        {
            if (message.Message is null) continue;
            stringBuilder.Append(message.Message);
            stringBuilder.Append('\n');
        }

        if (_messages.Any(message => message is SolutionMessage.Fail))
        {
            return new Results.Fail(stringBuilder.ToString());
        }

        if (_messages.Any(message => message is SolutionMessage.Warning))
        {
            return new Results.Warning(stringBuilder.ToString());
        }

        if (_messages.Any(message => message is SolutionMessage.Fail))
        {
            return new Results.Fail(stringBuilder.ToString());
        }

        return new Results.Success();
    }
}