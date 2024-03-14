using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.RenameFileCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class RenameGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "file rename path1 newname", typeof(HandleResult.Success), typeof(RenameFileCommand) };
        yield return new object[] { "file rename path", typeof(HandleResult.Fail), typeof(Nullable) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}