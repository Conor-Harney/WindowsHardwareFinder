using WindowsHardwareFinder.model.repo;

namespace WindowsHardwareFinder.model.view
{
    public enum HardwareObjectEnum
    {
        CoolingDevice,
        InputDevice,
        MassStorage,
        MotherboardControllerAndPort,
        NetworkingDevice,
        Power,
        Printing,
        Telephony,
        VideoAndMonitor
    }

    internal class HardwareObjectMetadataData
    {
        //Add entries for new Hardware Objects
        protected static Dictionary<HardwareObjectEnum, List<ComputerSystemHardwareClassEnum>> HardwareObjectRelatedTables = new Dictionary<HardwareObjectEnum, List<ComputerSystemHardwareClassEnum>>()
        {
            { HardwareObjectEnum.CoolingDevice, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_Fan, ComputerSystemHardwareClassEnum.Win32_HeatPipe, ComputerSystemHardwareClassEnum.Win32_Refrigeration, ComputerSystemHardwareClassEnum.Win32_TemperatureProbe } },
            { HardwareObjectEnum.InputDevice, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_DesktopMonitor, ComputerSystemHardwareClassEnum.Win32_DisplayControllerConfiguration, ComputerSystemHardwareClassEnum.Win32_VideoController, ComputerSystemHardwareClassEnum.Win32_VideoSettings } }
        };

        // Metadat on tables
        protected static Dictionary<ComputerSystemHardwareClassEnum, ComputerSystemHardwareMetadataData> TableFields { get; } = new Dictionary<ComputerSystemHardwareClassEnum, ComputerSystemHardwareMetadataData>();
    }
}
