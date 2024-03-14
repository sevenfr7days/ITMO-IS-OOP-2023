using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentRepository;

public interface IRepository
{
    void RegisterNewComponent(IComponent component);
    IComponent? GetComponent(string componentName);
}