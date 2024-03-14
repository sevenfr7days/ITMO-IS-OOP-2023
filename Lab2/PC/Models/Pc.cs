using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

public class Pc : IPc
{
    public Pc(
        IMotherboard? motherboard,
        ICpu? cpu,
        IBios? bios,
        ICoolingSystem? coolingSystem,
        ICollection<IRam>? rams,
        ICollection<ISsd> ssds,
        ICollection<IHdd> hdds,
        IXmpProfile? xmpProfile,
        IPcCase? pcPcCase,
        IPowerSupply? powerSupply,
        ICollection<IGpu> gpus,
        IWiFiAdapter? wiFiAdapter)
    {
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
        CoolingSystem = coolingSystem ?? throw new ArgumentNullException(nameof(coolingSystem));
        Rams = rams ?? throw new ArgumentNullException(nameof(rams));
        Ssds = ssds;
        Hdds = hdds;
        XmpProfile = xmpProfile;
        PcPcCase = pcPcCase ?? throw new ArgumentNullException(nameof(pcPcCase));
        PowerSupply = powerSupply ?? throw new ArgumentNullException(nameof(powerSupply));
        Gpus = gpus;
        WiFiAdapter = wiFiAdapter;
    }

    public IMotherboard Motherboard { get; }
    public ICpu Cpu { get; }
    public IBios Bios { get; }
    public ICoolingSystem CoolingSystem { get; }
    public ICollection<IRam> Rams { get; }
    public ICollection<ISsd> Ssds { get; }
    public ICollection<IHdd> Hdds { get; }
    public IXmpProfile? XmpProfile { get; }
    public IPcCase PcPcCase { get; }
    public IPowerSupply PowerSupply { get; }
    public ICollection<IGpu> Gpus { get; }
    public IWiFiAdapter? WiFiAdapter { get; }
}