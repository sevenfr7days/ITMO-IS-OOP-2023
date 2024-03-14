using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CopyFileCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CopyGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "file copy path1 path2", typeof(HandleResult.Success), typeof(CopyFileCommand) };
        yield return new object[] { "file copy path1", typeof(HandleResult.Fail), typeof(Nullable) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}