namespace WindowsHardwareFinder.model.repo
{
    //ref https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/computer-system-hardware-classes
    public enum ComputerSystemHardwareClassEnum
    {
        Win32_Fan,
        Win32_HeatPipe,
        Win32_Refrigeration,
        Win32_TemperatureProbe,

        Win32_Keyboard,
        Win32_PointingDevice,

        Win32_AutochkSetting,
        Win32_CDROMDrive,
        Win32_DiskDrive,
        Win32_FloppyDrive,
        Win32_PhysicalMedia,
        Win32_TapeDrive,

        Win32_1394Controller,
        Win32_1394ControllerDevice,
        Win32_AllocatedResource,
        Win32_AssociatedProcessorMemory,
        Win32_BaseBoard,
        Win32_BIOS,
        Win32_Bus,
        Win32_CacheMemory,
        Win32_ControllerHasHub,
        Win32_DeviceBus,
        Win32_DeviceMemoryAddress,
        Win32_DeviceSettings,
        Win32_DMAChannel,
        Win32_FloppyController,
        Win32_IDEController,
        Win32_IDEControllerDevice,
        Win32_InfraredDevice,
        Win32_IRQResource,
        Win32_MemoryArray,
        Win32_MemoryArrayLocation,
        Win32_MemoryDevice,
        Win32_MemoryDeviceArray,
        Win32_MemoryDeviceLocation,
        Win32_MotherboardDevice,
        Win32_OnBoardDevice,
        Win32_ParallelPort,
        Win32_PCMCIAController,
        Win32_PhysicalMemory,
        Win32_PhysicalMemoryArray,
        Win32_PhysicalMemoryLocation,
        Win32_PNPAllocatedResource,
        Win32_PNPDevice,
        Win32_PNPEntity,
        Win32_PortConnector,
        Win32_PortResource,
        Win32_Processor,
        Win32_SCSIController,
        Win32_SCSIControllerDevice,
        Win32_SerialPort,
        Win32_SerialPortConfiguration,
        Win32_SerialPortSetting,
        Win32_SMBIOSMemory,
        Win32_SoundDevice,
        Win32_SystemBIOS,
        Win32_SystemDriverPNPEntity,
        Win32_SystemEnclosure,
        Win32_SystemMemoryResource,
        Win32_SystemSlot,
        Win32_USBController,
        Win32_USBControllerDevice,
        Win32_USBHub,


        Win32_NetworkAdapter,
        Win32_NetworkAdapterConfiguration,
        Win32_NetworkAdapterSetting,


        Win32_Battery,
        Win32_CurrentProbe,
        Win32_PortableBattery,
        Win32_PowerManagementEvent,
        Win32_VoltageProbe,


        Win32_DriverForDevice,
        Win32_Printer,
        Win32_PrinterConfiguration,
        Win32_PrinterController,
        Win32_PrinterDriver,
        Win32_PrinterDriverDll,
        Win32_PrinterSetting,
        Win32_PrintJob,
        Win32_TCPIPPrinterPort,

        Win32_POTSModem,
        Win32_POTSModemToSerialPort,

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
