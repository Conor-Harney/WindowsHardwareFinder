namespace WindowsHardwareFinder.model.repo
{
    //ref https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/computer-system-hardware-classes
    public enum ComputerSystemHardwareClassEnum
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
    abstract class ComputerSystemHardwareMetadataData
    {
        protected static Dictionary<ComputerSystemHardwareClassEnum, List<string>> AvailibleFields = new();
        protected static Dictionary<ComputerSystemHardwareClassEnum, List<string>> DisplayFields = new();
    }
}
