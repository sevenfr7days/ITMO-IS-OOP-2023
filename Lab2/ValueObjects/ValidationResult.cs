using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record ValidationResult(bool IsValid, IReadOnlyCollection<SolutionMessage> SolutionMessages);
