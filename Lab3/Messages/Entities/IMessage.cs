using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public interface IMessage
{
    string Title { get; }
    string Body { get; }
    Id Id { get; }
    ImportanceLevel ImportanceLevel { get; }
    string ConvertMessageToString();
}