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
        // Add entries for new Hardware Objects
        protected static Dictionary<HardwareObjectEnum, List<ComputerSystemHardwareClassEnum>> HardwareObjectRelatedTables = new Dictionary<HardwareObjectEnum, List<ComputerSystemHardwareClassEnum>>()
        {
            { HardwareObjectEnum.CoolingDevice, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_Fan, ComputerSystemHardwareClassEnum.Win32_HeatPipe, ComputerSystemHardwareClassEnum.Win32_Refrigeration, ComputerSystemHardwareClassEnum.Win32_TemperatureProbe } },
            { HardwareObjectEnum.InputDevice, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_Keyboard, ComputerSystemHardwareClassEnum.Win32_PointingDevice} },
            { HardwareObjectEnum.MassStorage, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_AutochkSetting, ComputerSystemHardwareClassEnum.Win32_CDROMDrive, ComputerSystemHardwareClassEnum.Win32_DiskDrive, ComputerSystemHardwareClassEnum.Win32_FloppyDrive, ComputerSystemHardwareClassEnum.Win32_PhysicalMedia, ComputerSystemHardwareClassEnum.Win32_TapeDrive} },
            { HardwareObjectEnum.MotherboardControllerAndPort, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_1394Controller, ComputerSystemHardwareClassEnum.Win32_1394ControllerDevice, ComputerSystemHardwareClassEnum.Win32_AllocatedResource, ComputerSystemHardwareClassEnum.Win32_AssociatedProcessorMemory, ComputerSystemHardwareClassEnum.Win32_BaseBoard, ComputerSystemHardwareClassEnum.Win32_BIOS, ComputerSystemHardwareClassEnum.Win32_Bus, ComputerSystemHardwareClassEnum.Win32_CacheMemory, ComputerSystemHardwareClassEnum.Win32_ControllerHasHub, ComputerSystemHardwareClassEnum.Win32_DeviceBus, ComputerSystemHardwareClassEnum.Win32_DeviceMemoryAddress, ComputerSystemHardwareClassEnum.Win32_DeviceSettings, ComputerSystemHardwareClassEnum.Win32_DMAChannel, ComputerSystemHardwareClassEnum.Win32_FloppyController, ComputerSystemHardwareClassEnum.Win32_IDEController, ComputerSystemHardwareClassEnum.Win32_IDEControllerDevice, ComputerSystemHardwareClassEnum.Win32_InfraredDevice, ComputerSystemHardwareClassEnum.Win32_IRQResource, ComputerSystemHardwareClassEnum.Win32_MemoryArray, ComputerSystemHardwareClassEnum.Win32_MemoryArrayLocation, ComputerSystemHardwareClassEnum.Win32_MemoryDevice, ComputerSystemHardwareClassEnum.Win32_MemoryDeviceArray, ComputerSystemHardwareClassEnum.Win32_MemoryDeviceLocation, ComputerSystemHardwareClassEnum.Win32_MotherboardDevice, ComputerSystemHardwareClassEnum.Win32_OnBoardDevice, ComputerSystemHardwareClassEnum.Win32_ParallelPort, ComputerSystemHardwareClassEnum.Win32_PCMCIAController, ComputerSystemHardwareClassEnum.Win32_PhysicalMemory, ComputerSystemHardwareClassEnum.Win32_PhysicalMemoryArray, ComputerSystemHardwareClassEnum.Win32_PhysicalMemoryLocation, ComputerSystemHardwareClassEnum.Win32_PNPAllocatedResource, ComputerSystemHardwareClassEnum.Win32_PNPDevice, ComputerSystemHardwareClassEnum.Win32_PNPEntity, ComputerSystemHardwareClassEnum.Win32_PortConnector, ComputerSystemHardwareClassEnum.Win32_PortResource, ComputerSystemHardwareClassEnum.Win32_Processor, ComputerSystemHardwareClassEnum.Win32_SCSIController, ComputerSystemHardwareClassEnum.Win32_SCSIControllerDevice, ComputerSystemHardwareClassEnum.Win32_SerialPort, ComputerSystemHardwareClassEnum.Win32_SerialPortConfiguration, ComputerSystemHardwareClassEnum.Win32_SerialPortSetting, ComputerSystemHardwareClassEnum.Win32_SMBIOSMemory, ComputerSystemHardwareClassEnum.Win32_SoundDevice, ComputerSystemHardwareClassEnum.Win32_SystemBIOS, ComputerSystemHardwareClassEnum.Win32_SystemDriverPNPEntity, ComputerSystemHardwareClassEnum.Win32_SystemEnclosure, ComputerSystemHardwareClassEnum.Win32_SystemMemoryResource, ComputerSystemHardwareClassEnum.Win32_SystemSlot, ComputerSystemHardwareClassEnum.Win32_USBController, ComputerSystemHardwareClassEnum.Win32_USBControllerDevice, ComputerSystemHardwareClassEnum.Win32_USBHub } },
            { HardwareObjectEnum.NetworkingDevice, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_NetworkAdapter, ComputerSystemHardwareClassEnum.Win32_NetworkAdapterConfiguration, ComputerSystemHardwareClassEnum.Win32_NetworkAdapterSetting } },
            { HardwareObjectEnum.Power, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_Battery, ComputerSystemHardwareClassEnum.Win32_CurrentProbe, ComputerSystemHardwareClassEnum.Win32_PortableBattery, ComputerSystemHardwareClassEnum.Win32_PowerManagementEvent, ComputerSystemHardwareClassEnum.Win32_VoltageProbe } },
            { HardwareObjectEnum.Printing, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_DriverForDevice, ComputerSystemHardwareClassEnum.Win32_Printer, ComputerSystemHardwareClassEnum.Win32_PrinterConfiguration, ComputerSystemHardwareClassEnum.Win32_PrinterController, ComputerSystemHardwareClassEnum.Win32_PrinterDriver, ComputerSystemHardwareClassEnum.Win32_PrinterDriverDll, ComputerSystemHardwareClassEnum.Win32_PrinterSetting, ComputerSystemHardwareClassEnum.Win32_PrintJob, ComputerSystemHardwareClassEnum.Win32_TCPIPPrinterPort } },
            { HardwareObjectEnum.Telephony, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_POTSModem, ComputerSystemHardwareClassEnum.Win32_POTSModemToSerialPort } },
            { HardwareObjectEnum.VideoAndMonitor, new List<ComputerSystemHardwareClassEnum> { ComputerSystemHardwareClassEnum.Win32_DesktopMonitor, ComputerSystemHardwareClassEnum.Win32_DisplayControllerConfiguration, ComputerSystemHardwareClassEnum.Win32_VideoController, ComputerSystemHardwareClassEnum.Win32_VideoSettings } }
        };

        // Metadat on tables
        protected static Dictionary<ComputerSystemHardwareClassEnum, ComputerSystemHardwareMetadataData> TableFields { get; } = new Dictionary<ComputerSystemHardwareClassEnum, ComputerSystemHardwareMetadataData>();
    }
}
