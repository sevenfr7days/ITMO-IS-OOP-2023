using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

public record Request(IList<RequestComponent> Components);