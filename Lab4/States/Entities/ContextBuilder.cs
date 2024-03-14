using Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreeConfigs.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileShow.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.TreeListShows;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

public class ContextBuilder : IContextBuilder
{
    private IFileSystem? _fileSystem;
    private DirectoryTreeConfig? _directoryTreeConfig;
    private IShowFile? _showFileStrategy;
    private IShowTree? _showTreeStrategy;

    public IContextBuilder WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public IContextBuilder WithDirectoryTreeConfig(DirectoryTreeConfig directoryTreeConfig)
    {
        _directoryTreeConfig = directoryTreeConfig;
        return this;
    }

    public IContextBuilder WithShowFileStrategy(IShowFile showFileStrategy)
    {
        _showFileStrategy = showFileStrategy;
        return this;
    }

    public IContextBuilder WithTreeShowStrategy(IShowTree showTreeStrategy)
    {
        _showTreeStrategy = showTreeStrategy;
        return this;
    }

    public Context? Build()
    {
        if (_fileSystem is not null && _directoryTreeConfig is not null && _showFileStrategy is not null && _showTreeStrategy is not null)
        {
            return new Context(_fileSystem, _directoryTreeConfig, _showFileStrategy, _showTreeStrategy);
        }

        return null;
    }
}