using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Entities;

public interface ILogger
{
    public ResultType Log(string message);
}