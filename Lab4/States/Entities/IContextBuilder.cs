using Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreeConfigs.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileShow.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.TreeListShows;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

public interface IContextBuilder
{
    public IContextBuilder WithFileSystem(IFileSystem fileSystem);
    public IContextBuilder WithDirectoryTreeConfig(DirectoryTreeConfig directoryTreeConfig);
    public IContextBuilder WithShowFileStrategy(IShowFile showFileStrategy);
    public IContextBuilder WithTreeShowStrategy(IShowTree showTreeStrategy);
    public Context? Build();
}