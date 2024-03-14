using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;

public interface ICpuBuilder
{
    public CpuBuilder WithName(Name name);

    public CpuBuilder WithCoreFrequency(Gigahertz frequency);

    public CpuBuilder WithCoresQuantity(Quantity quantity);

    public CpuBuilder WithSocket(Socket socket);

    public CpuBuilder WithIntegratedVideoCore(bool isIntegrated);

    public CpuBuilder WithSupportedMemoryFrequencies(ICollection<Megahertz> frequencies);

    public CpuBuilder WithTdp(Watt tdp);

    public CpuBuilder WithPowerConsumption(Watt powerConsumption);

    public Models.Cpu Build();
}