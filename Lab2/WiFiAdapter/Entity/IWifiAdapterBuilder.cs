using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;

public interface IWifiAdapterBuilder
{
    public WifiAdapterBuilder WithName(Name name);

    public WifiAdapterBuilder WithWiFiVersion(Version version);

    public WifiAdapterBuilder WithBluetoothModule(bool haveModule);

    public WifiAdapterBuilder WithPcieVersion(Version version);

    public WifiAdapterBuilder WithPowerConsumption(Watt powerConsumption);

    public WifiAdapter Build();
}