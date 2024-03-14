using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ConnectGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "connect path", typeof(HandleResult.Success), typeof(ConnectCommand) };
        yield return new object[] { "connect", typeof(HandleResult.Fail), typeof(Nullable) };
        yield return new object[] { "connect path -m", typeof(HandleResult.Fail), typeof(Nullable) };
        yield return new object[] { "connect path -m local", typeof(HandleResult.Success), typeof(ConnectCommand) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}