using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

public abstract class ChainLinkBase : IChainLink
{
    protected IChainLink? Next { get; private set; }

    public void AddNext(IChainLink nextLink)
    {
        if (Next is null)
        {
            Next = nextLink;
        }
        else
        {
            Next.AddNext(nextLink);
        }
    }

    public abstract HandleResult Handle(Request request);
}