namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreeConfigs.Entities;

public class DirectoryTreeConfigFactory : IDirectoryTreeConfigFactory
{
    public DirectoryTreeConfig CreateConcreteDirectoryTreeConfig()
    {
        const string directorySymbol = "📁";
        const string fileSymbol = "📄";
        const string indent = "   ";
        const string branch = "|  ";
        return new DirectoryTreeConfig(directorySymbol, fileSymbol, indent, branch);
    }
}