using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentRepository;

public class Repository : IRepository
{
    private readonly Dictionary<string, ICpu> _cpus = new();
    private readonly Dictionary<string, IGpu> _gpus = new();
    private readonly Dictionary<string, IMotherboard> _motherboards = new();
    private readonly Dictionary<string, IPowerSupply> _powerSupplies = new();
    private readonly Dictionary<string, IRam> _rams = new();
    private readonly Dictionary<string, IHdd> _hdds = new();
    private readonly Dictionary<string, ISsd> _ssds = new();
    private readonly Dictionary<string, IWiFiAdapter> _wiFiAdapters = new();
    private readonly Dictionary<string, IXmpProfile> _xmpProfiles = new();

    public void RegisterNewComponent(IComponent component)
    {
        switch (component)
        {
            case ICpu cpu:
                _cpus[cpu.Name.Forename] = cpu;
                break;
            case IGpu gpu:
                _gpus[gpu.Name.Forename] = gpu;
                break;
            case IMotherboard motherboard:
                _motherboards[motherboard.Name.Forename] = motherboard;
                break;
            case IPowerSupply powerSupply:
                _powerSupplies[powerSupply.Name.Forename] = powerSupply;
                break;
            case IRam ram:
                _rams[ram.Name.Forename] = ram;
                break;
            case IHdd hdd:
                _hdds[hdd.Name.Forename] = hdd;
                break;
            case ISsd ssd:
                _ssds[ssd.Name.Forename] = ssd;
                break;
            case IWiFiAdapter wiFiAdapter:
                _wiFiAdapters[wiFiAdapter.Name.Forename] = wiFiAdapter;
                break;
            case IXmpProfile xmpProfile:
                _xmpProfiles[xmpProfile.Name.Forename] = xmpProfile;
                break;
        }
    }

    public IComponent? GetComponent(string componentName)
    {
        if (_cpus.TryGetValue(componentName, out ICpu? cpu))
        {
            return cpu;
        }

        if (_gpus.TryGetValue(componentName, out IGpu? gpu))
        {
            return gpu;
        }

        if (_motherboards.TryGetValue(componentName, out IMotherboard? motherboard))
        {
            return motherboard;
        }

        if (_powerSupplies.TryGetValue(componentName, out IPowerSupply? powerSupply))
        {
            return powerSupply;
        }

        if (_rams.TryGetValue(componentName, out IRam? ram))
        {
            return ram;
        }

        if (_hdds.TryGetValue(componentName, out IHdd? hdd))
        {
            return hdd;
        }

        if (_ssds.TryGetValue(componentName, out ISsd? ssd))
        {
            return ssd;
        }

        if (_wiFiAdapters.TryGetValue(componentName, out IWiFiAdapter? wiFiAdapter))
        {
            return wiFiAdapter;
        }

        if (_xmpProfiles.TryGetValue(componentName, out IXmpProfile? xmpProfile))
        {
            return xmpProfile;
        }

        return null;
    }
}