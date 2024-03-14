using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public class Message : IMessage
{
    public Message(string title, string body, ImportanceLevel importanceLevel, Id id)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
        Id = id;
    }

    public string Title { get; }
    public string Body { get; }
    public Id Id { get; }
    public ImportanceLevel ImportanceLevel { get; }

    public string ConvertMessageToString() => $"{Title}\n{Body}";
}