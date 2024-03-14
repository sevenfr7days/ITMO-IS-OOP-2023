using System;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;

public interface ILogMessageBuilder
{
    public LogMessageBuilder SetDataTime(DateTime dateTime);
    public LogMessageBuilder SetMessage(string message);
    public LogMessageBuildingResult Build();
}