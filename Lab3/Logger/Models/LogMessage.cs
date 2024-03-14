using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;

public class LogMessage : ILogMessage
{
    public LogMessage(DateTime date, string message)
    {
        DateTime = date;
        Message = message;
    }

    public DateTime DateTime { get; }
    public string Message { get; }
}