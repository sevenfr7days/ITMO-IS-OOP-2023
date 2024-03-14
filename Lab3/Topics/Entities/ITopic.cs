using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public interface ITopic
{
    void Send(IMessage message);
}