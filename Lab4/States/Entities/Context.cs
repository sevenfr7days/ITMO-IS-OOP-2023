using Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreeConfigs.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileShow.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.TreeListShows;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

public class Context : IContext
{
    public Context(IFileSystem fileSystem, DirectoryTreeConfig directoryTreeConfig, IShowFile showFileStrategy, IShowTree showTreeStrategy)
    {
        FileSystem = fileSystem;
        DirectoryTreeConfig = directoryTreeConfig;
        ShowFileStrategy = showFileStrategy;
        ShowTreeStrategy = showTreeStrategy;
        Mode = null;
        IsConnected = false;
        CurrentAbsolutePath = string.Empty;
    }

    public string CurrentAbsolutePath { get; private set; }
    public IFileSystem FileSystem { get; }
    public string? Mode { get; private set; }
    public bool IsConnected { get; private set; }
    public DirectoryTreeConfig DirectoryTreeConfig { get; private set; }
    public IShowFile ShowFileStrategy { get; private set; }
    public IShowTree ShowTreeStrategy { get; private set; }

    public void ChangeDirectory(string subDirectory)
    {
        CurrentAbsolutePath = FileSystem.Combine(CurrentAbsolutePath, subDirectory);
    }

    public void ChangeAbsolutePath(string absolutePath)
    {
        CurrentAbsolutePath = absolutePath;
    }

    public void Connect(string absolutePath, string mode)
    {
        Mode = mode;
        IsConnected = true;
        CurrentAbsolutePath = absolutePath;
    }

    public void Disconnect()
    {
        Mode = null;
        CurrentAbsolutePath = string.Empty;
    }

    public void GotoAction(string path)
    {
        if (FileSystem.IsPathRooted(path))
        {
            CurrentAbsolutePath = path;
        }
        else
        {
            CurrentAbsolutePath = FileSystem.Combine(CurrentAbsolutePath, path);
        }
    }
}