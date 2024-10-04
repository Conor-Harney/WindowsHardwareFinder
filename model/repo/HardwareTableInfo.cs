namespace WindowsHardwareFinder.model.repo
{
    //ref https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/computer-system-hardware-classes
    public enum ComputerSystemHardwareClass
    {
        Win32_Fan,
        Win32_HeatPipe,
        Win32_Refrigeration,
        Win32_TemperatureProbe,

        Win32_DesktopMonitor,
        Win32_DisplayControllerConfiguration,
        Win32_VideoController,
        Win32_VideoSettings

    }

    public enum HardwareObject
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

    internal class HardwareTableInfo
    {
        //Add entries for new Hardware Objects
        protected static Dictionary<HardwareObject, List<ComputerSystemHardwareClass>> HardwareObjectRelatedTables = new Dictionary<HardwareObject, List<ComputerSystemHardwareClass>>()
        {
            { HardwareObject.CoolingDevice, new List<ComputerSystemHardwareClass> { ComputerSystemHardwareClass.Win32_Fan, ComputerSystemHardwareClass.Win32_HeatPipe, ComputerSystemHardwareClass.Win32_Refrigeration, ComputerSystemHardwareClass.Win32_TemperatureProbe } },
            { HardwareObject.InputDevice, new List<ComputerSystemHardwareClass> { ComputerSystemHardwareClass.Win32_DesktopMonitor, ComputerSystemHardwareClass.Win32_DisplayControllerConfiguration, ComputerSystemHardwareClass.Win32_VideoController, ComputerSystemHardwareClass.Win32_VideoSettings } }
        };

        // Populated from repo calls as and when needed 
        protected static Dictionary<ComputerSystemHardwareClass, List<string>> TableFields { get; } = new Dictionary<ComputerSystemHardwareClass, List<string>>();
    }
}
