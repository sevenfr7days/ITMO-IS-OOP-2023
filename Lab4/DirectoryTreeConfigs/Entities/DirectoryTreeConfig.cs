namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreeConfigs.Entities;

public class DirectoryTreeConfig
{
    public DirectoryTreeConfig(string directorySymbol, string fileSymbol, string indent, string branch)
    {
        DirectorySymbol = directorySymbol;
        FileSymbol = fileSymbol;
        Indent = indent;
        Branch = branch;
    }

    public string DirectorySymbol { get; private set; }
    public string FileSymbol { get; private set; }
    public string Indent { get; private set; }
    public string Branch { get; private set; }
}