using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileShowGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "file show path", typeof(HandleResult.Success), typeof(ShowFileCommand) };
        yield return new object[] { "file show", typeof(HandleResult.Fail), typeof(Nullable) };
        yield return new object[] { "file show -m console", typeof(HandleResult.Success), typeof(ShowFileCommand) };
        yield return new object[] { "file show -m", typeof(HandleResult.Fail), typeof(Nullable) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}