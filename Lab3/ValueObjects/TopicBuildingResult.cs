using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public abstract record TopicBuildingResult
{
    private TopicBuildingResult()
    {
    }

    private TopicBuildingResult(ITopic topic)
    {
        Topic = topic;
    }

    public ITopic? Topic { get; }

    public sealed record Fail() : TopicBuildingResult();

    public sealed record Success(ITopic Topic) : TopicBuildingResult(Topic);
}