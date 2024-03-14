using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Generator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { ImportanceLevel.ExtraLow, ImportanceLevel.Low };
        yield return new object[] { ImportanceLevel.Low, ImportanceLevel.Medium };
        yield return new object[] { ImportanceLevel.Medium, ImportanceLevel.High };
        yield return new object[] { ImportanceLevel.High, ImportanceLevel.ExtraHigh };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}