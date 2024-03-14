using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Entities;

public interface ITreeVisitor
{
    void VisitDirectory(string path, int depth, Context context, string indent);
    void VisitFile(string path, Context context, string indent);
}