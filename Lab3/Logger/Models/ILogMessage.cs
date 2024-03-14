using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;

public interface ILogMessage
{
    public DateTime DateTime { get; }
    public string Message { get; }
}