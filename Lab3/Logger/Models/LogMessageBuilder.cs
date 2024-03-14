using System;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;

public class LogMessageBuilder : ILogMessageBuilder
{
    private DateTime? _dateTime;
    private string? _message;

    public LogMessageBuilder SetDataTime(DateTime dateTime)
    {
        _dateTime = dateTime;
        return this;
    }

    public LogMessageBuilder SetMessage(string message)
    {
        _message = message;
        return this;
    }

    public LogMessageBuildingResult Build()
    {
        if (_dateTime is null || _message is null)
        {
            return new LogMessageBuildingResult.Fail();
        }

        return new LogMessageBuildingResult.Success(
            new LogMessage(
                _dateTime.Value,
                _message));
    }
}