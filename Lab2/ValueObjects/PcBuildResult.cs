using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record PcBuildResult(IPc? Pc, Results BuildMessages);