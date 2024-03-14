using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Models;

public class MotherboardBuilder : IMotherboardBuilder
{
    private Name? _name;
    private Socket? _socket;
    private Quantity? _pciLinesQuantity;
    private Quantity? _sataPortsQuantity;
    private IChipset? _chipset;
    private Version? _ddrStandard;
    private Quantity? _ramPortsQuantity;
    private FormFactor? _formFactor;
    private IBios? _bios;

    public MotherboardBuilder()
    {
    }

    public MotherboardBuilder(IMotherboard innerMotherboard)
    {
        _name = innerMotherboard.Name;
        _socket = innerMotherboard.Socket;
        _pciLinesQuantity = innerMotherboard.PciLinesQuantity;
        _sataPortsQuantity = innerMotherboard.SataPortsQuantity;
        _chipset = innerMotherboard.Chipset;
        _ddrStandard = innerMotherboard.DdrStandard;
        _ramPortsQuantity = innerMotherboard.RamPortsQuantity;
        _formFactor = innerMotherboard.FormFactor;
        _bios = innerMotherboard.Bios;
    }

    public MotherboardBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public MotherboardBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder WithPciLinesQuantity(Quantity quantity)
    {
        _pciLinesQuantity = quantity;
        return this;
    }

    public MotherboardBuilder WithSataPortsQuantity(Quantity quantity)
    {
        _sataPortsQuantity = quantity;
        return this;
    }

    public MotherboardBuilder WithChipset(IChipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder WithDdrStandard(Version standard)
    {
        _ddrStandard = standard;
        return this;
    }

    public MotherboardBuilder WithRamPortsQuantity(Quantity quantity)
    {
        _ramPortsQuantity = quantity;
        return this;
    }

    public MotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name,
            _socket,
            _pciLinesQuantity,
            _sataPortsQuantity,
            _chipset,
            _ddrStandard,
            _ramPortsQuantity,
            _formFactor,
            _bios);
    }
}