using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

public interface IChainLink
{
    void AddNext(IChainLink nextLink);

    HandleResult Handle(Request request);
}