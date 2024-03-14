using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TreeGotoGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "tree goto path", typeof(HandleResult.Success), typeof(TreeGotoCommand) };
        yield return new object[] { "tree goto", typeof(HandleResult.Fail), typeof(Nullable) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}