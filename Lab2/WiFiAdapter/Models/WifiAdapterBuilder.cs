using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Models;

public class WifiAdapterBuilder : IWifiAdapterBuilder
{
    private Name? _name;
    private Version? _wifiVersion;
    private bool? _haveBluetoothModule;
    private Version? _pcieVersion;
    private Watt? _powerConsumption;

    public WifiAdapterBuilder(IWiFiAdapter innerWiFiAdapter)
    {
        _name = innerWiFiAdapter.Name;
        _wifiVersion = innerWiFiAdapter.WiFiVersion;
        _haveBluetoothModule = innerWiFiAdapter.HaveBluetoothModule;
        _pcieVersion = innerWiFiAdapter.PcieVersion;
        _powerConsumption = innerWiFiAdapter.PowerConsumption;
    }

    public WifiAdapterBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public WifiAdapterBuilder WithWiFiVersion(Version version)
    {
        _wifiVersion = version;
        return this;
    }

    public WifiAdapterBuilder WithBluetoothModule(bool haveModule)
    {
        _haveBluetoothModule = haveModule;
        return this;
    }

    public WifiAdapterBuilder WithPcieVersion(Version version)
    {
        _pcieVersion = version;
        return this;
    }

    public WifiAdapterBuilder WithPowerConsumption(Watt powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WifiAdapter Build()
    {
        return new WifiAdapter(
            _name,
            _wifiVersion,
            _haveBluetoothModule,
            _pcieVersion,
            _powerConsumption);
    }
}