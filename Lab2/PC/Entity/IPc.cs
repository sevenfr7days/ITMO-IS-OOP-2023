using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;

public interface IPc
{
    IMotherboard Motherboard { get; }
    ICpu Cpu { get; }
    IBios Bios { get; }
    ICoolingSystem CoolingSystem { get; }
    ICollection<IRam> Rams { get; }
    ICollection<ISsd> Ssds { get; }
    ICollection<IHdd> Hdds { get; }
    IXmpProfile? XmpProfile { get; }
    IPcCase PcPcCase { get; }
    IPowerSupply PowerSupply { get; }
    ICollection<IGpu> Gpus { get; }
    IWiFiAdapter? WiFiAdapter { get; }
}