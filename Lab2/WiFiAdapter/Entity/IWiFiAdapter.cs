using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;

public interface IWiFiAdapter : IComponent
{
    Version WiFiVersion { get; }
    bool HaveBluetoothModule { get; }
    Version PcieVersion { get; }
    Watt PowerConsumption { get; }
}