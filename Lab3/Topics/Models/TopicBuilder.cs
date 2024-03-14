using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;

public class TopicBuilder : ITopicBuilder
{
    private string? _name;
    private IRecipient? _recipient;

    public TopicBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public TopicBuilder SetRecipient(IRecipient recipient)
    {
        _recipient = recipient;
        return this;
    }

    public TopicBuildingResult Build()
    {
        if (_name is null || _recipient is null)
        {
            return new TopicBuildingResult.Fail();
        }

        return new TopicBuildingResult.Success(
            new Topic(
                _name,
                _recipient));
    }
}