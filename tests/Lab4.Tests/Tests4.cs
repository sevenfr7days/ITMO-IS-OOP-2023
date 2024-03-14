using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests4
{
    [Theory]
    [ClassData(typeof(ConnectGenerator))]
    [ClassData(typeof(TreeListGenerator))]
    [ClassData(typeof(TreeGotoGenerator))]
    [ClassData(typeof(FileShowGenerator))]
    [ClassData(typeof(MoveGenerator))]
    [ClassData(typeof(CopyGenerator))]
    [ClassData(typeof(DeleteGenerator))]
    [ClassData(typeof(RenameGenerator))]
    [ClassData(typeof(DisconnectGenerator))]
    public void CommandTests(string requestString, Type expectedResultType, Type? expectedCommandType)
    {
        ChainLinkBase chain = new ChainOfResponsibilityFactory().CreateChain();
        var request = new Request(requestString.Split().Select(v => new RequestComponent(v)).ToList());

        HandleResult result = chain.Handle(request);

        Assert.IsType(expectedResultType, result);
        if (expectedResultType == typeof(HandleResult.Success) && expectedCommandType is not null)
        {
            var successResult = (HandleResult.Success)result;
            Assert.IsType(expectedCommandType, successResult.Command);
        }
    }
}