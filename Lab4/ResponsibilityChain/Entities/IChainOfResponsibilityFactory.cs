namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

public interface IChainOfResponsibilityFactory
{
    public ChainLinkBase CreateChain();
}