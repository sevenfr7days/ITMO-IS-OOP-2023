using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.FileResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.TreeResponsibilityChain.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

public class ChainOfResponsibilityFactory : IChainOfResponsibilityFactory
{
    public ChainLinkBase CreateChain()
    {
        var connectCommandHandler = new ConnectCommandHandler();
        var disconnectCommandHandler = new DisconnectCommandHandler();
        var treeGotoCommandHandler = new TreeGotoCommandHandler();
        var treeListCommandHandler = new TreeListCommandHandler();
        var showHandler = new FileShowCommandHandler();
        var moveHandler = new FileMoveCommandHandler();
        var copyHandler = new FileCopyCommandHandler();
        var deleteHandler = new FileDeleteCommandHandler();
        var renameHandler = new FileRenameCommandHandler();

        deleteHandler.AddNext(renameHandler);
        copyHandler.AddNext(deleteHandler);
        moveHandler.AddNext(copyHandler);
        showHandler.AddNext(moveHandler);
        treeListCommandHandler.AddNext(showHandler);
        treeGotoCommandHandler.AddNext(treeListCommandHandler);
        disconnectCommandHandler.AddNext(treeGotoCommandHandler);
        connectCommandHandler.AddNext(disconnectCommandHandler);

        return connectCommandHandler;
    }
}