using System;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;
using Version = Itmo.ObjectOrientedProgramming.Lab2.ValueObjects.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Models;

public class WifiAdapter : IWiFiAdapter
{
    public WifiAdapter(
        Name? name,
        Version? wiFiVersion,
        bool? haveBluetoothModule,
        Version? pcieVersion,
        Watt? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        WiFiVersion = wiFiVersion ?? throw new ArgumentNullException(nameof(wiFiVersion));
        HaveBluetoothModule = haveBluetoothModule ?? throw new ArgumentNullException(nameof(haveBluetoothModule));
        PcieVersion = pcieVersion ?? throw new ArgumentNullException(nameof(pcieVersion));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public Version WiFiVersion { get; }
    public bool HaveBluetoothModule { get; }
    public Version PcieVersion { get; }
    public Watt PowerConsumption { get; }
    public Name Name { get; }
}