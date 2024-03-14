using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class PCBuilderTests
{
    [Fact]
    public void SuccessBuild()
    {
        ICpu cpu1 = new CpuBuilder().WithName(new Name("Intel Core i7-10700K"))
            .WithSocket(new Socket("LGA1200"))
            .WithCoreFrequency(new Gigahertz(3.8))
            .WithCoresQuantity(new Quantity(8))
            .WithIntegratedVideoCore(true)
            .WithSupportedMemoryFrequencies(new List<Megahertz>
            {
                new Megahertz(2933), new Megahertz(2800), new Megahertz(2666), new Megahertz(2400), new Megahertz(2133),
            })
            .WithTdp(new Watt(125))
            .WithPowerConsumption(new Watt(125))
            .Build();

        ICpu cpu3 = new CpuBuilder().WithName(new Name("Intel Core i5-11600K"))
            .WithSocket(new Socket("LGA1200"))
            .WithCoreFrequency(new Gigahertz(3.9))
            .WithCoresQuantity(new Quantity(6))
            .WithIntegratedVideoCore(true)
            .WithSupportedMemoryFrequencies(new List<Megahertz>
            {
                new Megahertz(2933), new Megahertz(2800), new Megahertz(2666), new Megahertz(2400), new Megahertz(2133),
            })
            .WithTdp(new Watt(125))
            .WithPowerConsumption(new Watt(125))
            .Build();
        var supportedCpus = new List<ICpu>() { cpu1, cpu3 };

        IBios bios = new BiosBuilder().WithName(new Name("American Megatrends Inc. P1.40"))
            .WithBiosType(new BiosType("EUFI"))
            .WithBiosVersion(new BiosVersion(1.40))
            .WithSupportedCpus(supportedCpus)
            .Build();

        IXmpProfile xmpProfile = new XmpBuilder().WithCl(16)
            .WithName(new Name("dsdsd"))
            .WithTrcd(18)
            .WithTrp(18)
            .WithTras(36)
            .WithVoltage(new Voltage(135))
            .WithFrequency(new Megahertz(3600))
            .Build();
        IHdd hdd = new HddBuilder().WithName(new Name("WD Blue 1TB"))
            .WithCapacity(new MemorySize(1000))
            .WithPowerConsumption(new Watt(6))
            .WithSpindleSpeed(new SpindleSpeed(7200))
            .Build();

        IRam ram = new RamBuilder().WithName(new Name("Corsair Vengeance LPX 16GB (2 x 8GB) DDR4-3600"))
            .WithAvailableMemorySize(new MemorySize(16))
            .WithJedecFrequenciesAndVoltages(new List<(Megahertz, Voltage)>
            {
                (new Megahertz(2133), new Voltage(1.2)),
                (new Megahertz(2400), new Voltage(1.2)),
                (new Megahertz(2666), new Voltage(1.2)),
                (new Megahertz(2933), new Voltage(1.35)),
            })
            .WithXmpProfiles(new List<IXmpProfile> { xmpProfile })
            .WithFormFactor(new FormFactor("DIMM"))
            .WithDdrStandard(new Version(4))
            .WithPowerConsumption(new Watt(5))
            .Build();
        IPowerSupply powerSupply = new PowerSupplyBuilder()
            .WithName(new Name("Corsair RM850x 850 Watt 80 PLUS Gold Certified"))
            .WithPeakLoadPower(new Watt(850))
            .Build();

        // Создание объекта материнской платы
        IMotherboard motherboard = new MotherboardBuilder().WithName(new Name("ASUS PRIME Z590-P"))
            .WithSocket(new Socket("LGA1200"))
            .WithPciLinesQuantity(new Quantity(24))
            .WithSataPortsQuantity(new Quantity(6))
            .WithChipset(new Chipset(
                new List<Megahertz>
                {
                    new Megahertz(3200), new Megahertz(3000), new Megahertz(2933), new Megahertz(2800),
                    new Megahertz(2666),
                },
                new List<IXmpProfile> { xmpProfile }))
            .WithDdrStandard(new Version(4))
            .WithRamPortsQuantity(new Quantity(4))
            .WithFormFactor(new FormFactor("ATX"))
            .WithBios(bios)
            .Build();
        IGpu gpu = new GpuBuilder().WithName(new Name("NVIDIA GeForce RTX 3080"))
            .WithLength(new Millimeters(285))
            .WithWidth(new Millimeters(112))
            .WithPcieVersion(new Version(4))
            .WithChipFrequency(new Megahertz(1440))
            .WithPowerConsumption(new Watt(320))
            .WithMemory(new MemorySize(8))
            .Build();
        ICoolingSystem coolingSystem = new CoolingSystemBuilder().WithName(new Name("Cooler Master Hyper 212 EVO"))
            .WithSize(new Millimeters(120), new Millimeters(80), new Millimeters(159))
            .WithMaxTdp(new Watt(150))
            .WithSupportedSockets(new List<Socket> { new Socket("LGA1200"), new Socket("AM4") })
            .Build();
        IPcCase pcCase = new PcCaseBuilder().WithMaxGpuSizes(new Millimeters(350), new Millimeters(150))
            .WithSupportedMotherboardsFactors(new List<FormFactor>
                { new FormFactor("ATX"), new FormFactor("Micro-ATX") })
            .WithSizes(new Millimeters(450), new Millimeters(210), new Millimeters(480))
            .WithName(new Name("copous"))
            .Build();
        (IPc? pc, Results result) = new PcBuilder().SetBios(bios).SetCpu(cpu1).SetGpu(new List<IGpu>() { gpu })
            .SetMotherboard(motherboard)
            .SetHdds(new List<IHdd>() { hdd }).SetRam(new List<IRam>() { ram }).SetCoolingSystem(coolingSystem)
            .SetPcCase(pcCase).SetPowerSupply(powerSupply).SetXmpProfile(xmpProfile).Build();
        Assert.NotNull(pc);
        Assert.True(result is Results.Success);
    }

    [Fact]
    public void SuccessBuildWithWarningResult()
    {
        ICpu cpu1 = new CpuBuilder().WithName(new Name("Intel Core i7-10700K"))
            .WithSocket(new Socket("LGA1200"))
            .WithCoreFrequency(new Gigahertz(3.8))
            .WithCoresQuantity(new Quantity(8))
            .WithIntegratedVideoCore(true)
            .WithSupportedMemoryFrequencies(new List<Megahertz>
            {
                new Megahertz(2933), new Megahertz(2800), new Megahertz(2666), new Megahertz(2400), new Megahertz(2133),
            })
            .WithTdp(new Watt(125))
            .WithPowerConsumption(new Watt(125))
            .Build();

        ICpu cpu3 = new CpuBuilder(cpu1).WithTdp(new Watt(200)).Build();
        var supportedCpus = new List<ICpu>() { cpu3 };

        IBios bios = new BiosBuilder().WithName(new Name("American Megatrends Inc. P1.40"))
            .WithBiosType(new BiosType("EUFI"))
            .WithBiosVersion(new BiosVersion(1.40))
            .WithSupportedCpus(supportedCpus)
            .Build();

        IXmpProfile xmpProfile = new XmpBuilder().WithCl(16)
            .WithName(new Name("dsdsd"))
            .WithTrcd(18)
            .WithTrp(18)
            .WithTras(36)
            .WithVoltage(new Voltage(135))
            .WithFrequency(new Megahertz(3600))
            .Build();
        IHdd hdd = new HddBuilder().WithName(new Name("WD Blue 1TB"))
            .WithCapacity(new MemorySize(1000))
            .WithPowerConsumption(new Watt(6))
            .WithSpindleSpeed(new SpindleSpeed(7200))
            .Build();

        IRam ram = new RamBuilder().WithName(new Name("Corsair Vengeance LPX 16GB (2 x 8GB) DDR4-3600"))
            .WithAvailableMemorySize(new MemorySize(16))
            .WithJedecFrequenciesAndVoltages(new List<(Megahertz, Voltage)>
            {
                (new Megahertz(2133), new Voltage(1.2)),
                (new Megahertz(2400), new Voltage(1.2)),
                (new Megahertz(2666), new Voltage(1.2)),
                (new Megahertz(2933), new Voltage(1.35)),
            })
            .WithXmpProfiles(new List<IXmpProfile> { xmpProfile })
            .WithFormFactor(new FormFactor("DIMM"))
            .WithDdrStandard(new Version(4))
            .WithPowerConsumption(new Watt(5))
            .Build();
        IPowerSupply powerSupply = new PowerSupplyBuilder()
            .WithName(new Name("Corsair RM850x 850 Watt 80 PLUS Gold Certified"))
            .WithPeakLoadPower(new Watt(850))
            .Build();

        // Создание объекта материнской платы
        IMotherboard motherboard = new MotherboardBuilder().WithName(new Name("ASUS PRIME Z590-P"))
            .WithSocket(new Socket("LGA1200"))
            .WithPciLinesQuantity(new Quantity(24))
            .WithSataPortsQuantity(new Quantity(6))
            .WithChipset(new Chipset(
                new List<Megahertz>
                {
                    new Megahertz(3200), new Megahertz(3000), new Megahertz(2933), new Megahertz(2800),
                    new Megahertz(2666),
                },
                new List<IXmpProfile> { xmpProfile }))
            .WithDdrStandard(new Version(4))
            .WithRamPortsQuantity(new Quantity(4))
            .WithFormFactor(new FormFactor("ATX"))
            .WithBios(bios)
            .Build();
        IGpu gpu = new GpuBuilder().WithName(new Name("NVIDIA GeForce RTX 3080"))
            .WithLength(new Millimeters(285))
            .WithWidth(new Millimeters(112))
            .WithPcieVersion(new Version(4))
            .WithChipFrequency(new Megahertz(1440))
            .WithPowerConsumption(new Watt(320))
            .WithMemory(new MemorySize(8))
            .Build();
        ICoolingSystem coolingSystem = new CoolingSystemBuilder().WithName(new Name("Cooler Master Hyper 212 EVO"))
            .WithSize(new Millimeters(120), new Millimeters(80), new Millimeters(159))
            .WithMaxTdp(new Watt(150))
            .WithSupportedSockets(new List<Socket> { new Socket("LGA1200"), new Socket("AM4") })
            .Build();
        IPcCase pcCase = new PcCaseBuilder().WithMaxGpuSizes(new Millimeters(350), new Millimeters(150))
            .WithSupportedMotherboardsFactors(new List<FormFactor>
                { new FormFactor("ATX"), new FormFactor("Micro-ATX") })
            .WithSizes(new Millimeters(450), new Millimeters(210), new Millimeters(480))
            .WithName(new Name("copous"))
            .Build();
        (IPc? pc, Results result) = new PcBuilder().SetBios(bios).SetCpu(cpu3).SetGpu(new List<IGpu>() { gpu })
            .SetMotherboard(motherboard)
            .SetHdds(new List<IHdd>() { hdd }).SetRam(new List<IRam>() { ram }).SetCoolingSystem(coolingSystem)
            .SetPcCase(pcCase).SetPowerSupply(powerSupply).SetXmpProfile(xmpProfile).Build();
        Assert.NotNull(pc);
        Assert.True(result is Results.Warning);
    }

    [Fact]
    public void FailBuild()
    {
        ICpu cpu1 = new CpuBuilder().WithName(new Name("Intel Core i7-10700K"))
            .WithSocket(new Socket("LGA1200"))
            .WithCoreFrequency(new Gigahertz(3.8))
            .WithCoresQuantity(new Quantity(8))
            .WithIntegratedVideoCore(true)
            .WithSupportedMemoryFrequencies(new List<Megahertz>
            {
                new Megahertz(2933), new Megahertz(2800), new Megahertz(2666), new Megahertz(2400), new Megahertz(2133),
            })
            .WithTdp(new Watt(125))
            .WithPowerConsumption(new Watt(125))
            .Build();

        ICpu cpu3 = new CpuBuilder().WithName(new Name("Intel Core i5-11600K"))
            .WithSocket(new Socket("LGA1200"))
            .WithCoreFrequency(new Gigahertz(3.9))
            .WithCoresQuantity(new Quantity(6))
            .WithIntegratedVideoCore(true)
            .WithSupportedMemoryFrequencies(new List<Megahertz>
            {
                new Megahertz(2933), new Megahertz(2800), new Megahertz(2666), new Megahertz(2400), new Megahertz(2133),
            })
            .WithTdp(new Watt(125))
            .WithPowerConsumption(new Watt(125))
            .Build();
        var supportedCpus = new List<ICpu>() { cpu1, cpu3 };

        IBios bios = new BiosBuilder().WithName(new Name("American Megatrends Inc. P1.40"))
            .WithBiosType(new BiosType("EUFI"))
            .WithBiosVersion(new BiosVersion(1.40))
            .WithSupportedCpus(supportedCpus)
            .Build();

        IXmpProfile xmpProfile = new XmpBuilder().WithCl(16)
            .WithName(new Name("dsdsd"))
            .WithTrcd(18)
            .WithTrp(18)
            .WithTras(36)
            .WithVoltage(new Voltage(135))
            .WithFrequency(new Megahertz(3600))
            .Build();
        IHdd hdd = new HddBuilder().WithName(new Name("WD Blue 1TB"))
            .WithCapacity(new MemorySize(1000))
            .WithPowerConsumption(new Watt(6))
            .WithSpindleSpeed(new SpindleSpeed(7200))
            .Build();

        IRam ram = new RamBuilder().WithName(new Name("Corsair Vengeance LPX 16GB (2 x 8GB) DDR4-3600"))
            .WithAvailableMemorySize(new MemorySize(16))
            .WithJedecFrequenciesAndVoltages(new List<(Megahertz, Voltage)>
            {
                (new Megahertz(2133), new Voltage(1.2)),
                (new Megahertz(2400), new Voltage(1.2)),
                (new Megahertz(2666), new Voltage(1.2)),
                (new Megahertz(2933), new Voltage(1.35)),
            })
            .WithXmpProfiles(new List<IXmpProfile> { xmpProfile })
            .WithFormFactor(new FormFactor("DIMM"))
            .WithDdrStandard(new Version(4))
            .WithPowerConsumption(new Watt(5))
            .Build();
        IPowerSupply powerSupply = new PowerSupplyBuilder()
            .WithName(new Name("Corsair RM850x 850 Watt 80 PLUS Gold Certified"))
            .WithPeakLoadPower(new Watt(850))
            .Build();

        // Создание объекта материнской платы
        IMotherboard motherboard = new MotherboardBuilder().WithName(new Name("ASUS PRIME B450M-A"))
            .WithSocket(new Socket("AM4")) // несовместимый сокет
            .WithPciLinesQuantity(new Quantity(24))
            .WithSataPortsQuantity(new Quantity(6))
            .WithChipset(new Chipset(
                new List<Megahertz>
                {
                    new Megahertz(3200), new Megahertz(3000), new Megahertz(2933), new Megahertz(2800),
                    new Megahertz(2666),
                },
                new List<IXmpProfile> { xmpProfile }))
            .WithDdrStandard(new Version(4))
            .WithRamPortsQuantity(new Quantity(4))
            .WithFormFactor(new FormFactor("Micro-ATX"))
            .WithBios(bios)
            .Build();

        IGpu gpu = new GpuBuilder().WithName(new Name("NVIDIA GeForce RTX 3080"))
            .WithLength(new Millimeters(285))
            .WithWidth(new Millimeters(112))
            .WithPcieVersion(new Version(4))
            .WithChipFrequency(new Megahertz(1440))
            .WithPowerConsumption(new Watt(320))
            .WithMemory(new MemorySize(8))
            .Build();
        ICoolingSystem coolingSystem = new CoolingSystemBuilder().WithName(new Name("Cooler Master Hyper 212 EVO"))
            .WithSize(new Millimeters(120), new Millimeters(80), new Millimeters(159))
            .WithMaxTdp(new Watt(150))
            .WithSupportedSockets(new List<Socket> { new Socket("LGA1200"), new Socket("AM4") })
            .Build();
        IPcCase pcCase = new PcCaseBuilder().WithMaxGpuSizes(new Millimeters(350), new Millimeters(150))
            .WithSupportedMotherboardsFactors(new List<FormFactor>
                { new FormFactor("ATX"), new FormFactor("Micro-ATX"), new FormFactor("Mini-ITX") })
            .WithSizes(new Millimeters(450), new Millimeters(210), new Millimeters(480))
            .WithName(new Name("copous"))
            .Build();
        (IPc? pc, Results results) = new PcBuilder().SetBios(bios).SetCpu(cpu1).SetGpu(new List<IGpu>() { gpu })
            .SetMotherboard(motherboard)
            .SetHdds(new List<IHdd>() { hdd }).SetRam(new List<IRam>() { ram }).SetCoolingSystem(coolingSystem)
            .SetPcCase(pcCase).SetPowerSupply(powerSupply).SetXmpProfile(xmpProfile).Build();
        Assert.True(results is Results.Fail);
        Assert.Null(pc);
    }
}