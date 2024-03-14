namespace Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

public interface IContext
{
    public void ChangeDirectory(string subDirectory);

    public void ChangeAbsolutePath(string absolutePath);

    public void Connect(string absolutePath, string mode);

    public void Disconnect();

    public void GotoAction(string path);
}