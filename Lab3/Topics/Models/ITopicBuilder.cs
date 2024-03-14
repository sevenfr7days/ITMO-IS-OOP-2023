using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;

public interface ITopicBuilder
{
    public TopicBuilder SetName(string name);
    public TopicBuilder SetRecipient(IRecipient recipient);
    public TopicBuildingResult Build();
}