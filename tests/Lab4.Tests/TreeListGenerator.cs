using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TreeListGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "tree list", typeof(HandleResult.Success), typeof(TreeListCommand) };
        yield return new object[] { "list", typeof(HandleResult.Fail), typeof(Nullable) };
        yield return new object[] { "tree list -d 1", typeof(HandleResult.Success), typeof(TreeListCommand) };
        yield return new object[] { "tree list -d abacaba", typeof(HandleResult.Fail), typeof(Nullable) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}