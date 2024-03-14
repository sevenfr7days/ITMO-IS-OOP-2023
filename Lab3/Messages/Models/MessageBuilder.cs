using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public class MessageBuilder : IMessageBuilder
{
    private string? _title;
    private string? _body;
    private Id? _id;
    private ImportanceLevel? _importanceLevel;

    public MessageBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public MessageBuilder SetBody(string body)
    {
        _body = body;
        return this;
    }

    public MessageBuilder SetId(Id id)
    {
        _id = id;
        return this;
    }

    public MessageBuilder SetImportanceLevel(ImportanceLevel importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public MessageBuildingResult Build()
    {
        if (_title is null || _body is null || _importanceLevel is null || _id is null)
        {
            return new MessageBuildingResult.Fail();
        }

        return new MessageBuildingResult.Success(
            new Message(
                _title,
                _body,
                _importanceLevel.Value,
                _id));
    }
}