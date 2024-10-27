using System.Management;
using WindowsHardwareFinder.model.repo;
using WindowsHardwareFinder.model.view;
using WindowsHardwareFinder.modelView.repo;
using WindowsHardwareFinder.viewmodel.service.repo;
using WindowsHardwareFinder.viewmodel.service.view;

namespace WindowsHardwareFinder.view.parser
{
    internal static class HardwareTableParser
    {
        public static string UserFriendlyTable(HardwareObjectEnum hardwareObjectName)
        {
            HardwareObjectData hardwareObjectData = ParseHardwareObject(hardwareObjectName);
            string data = hardwareObjectName.ToString() + ":\r\n";
            foreach (KeyValuePair<ComputerSystemHardwareClassEnum, List<ComputerSystemHardwareData>> hardwareObjectDataPair in hardwareObjectData.GetComputerSystemHardwareClassData())
            {
                data += "\t" + hardwareObjectDataPair.Key.ToString() + ":\r\n";
                List<ComputerSystemHardwareData> tableData = hardwareObjectDataPair.Value;
                foreach (ComputerSystemHardwareData rowData in tableData)
                {
                    foreach (KeyValuePair<string, string> field in rowData.GetFields())
                    {
                        data += "\t\t" + field.Key + ": " + field.Value + "\r\n";
                    }
                    data += "\r\n";
                }
                data += "\r\n";
            }
            return data;
        }
        
        public static HardwareObjectData ParseHardwareObject(HardwareObjectEnum hardwareObject) 
        {
            HardwareObjectData hardwareObjectData = new(hardwareObject);
            foreach (ComputerSystemHardwareClassEnum table in HardwareObjectService.GetTablesForObject(hardwareObject))
            {
                ManagementObjectCollection rows = HardwareObjectRepo.queryAll(table);
                List<ComputerSystemHardwareData> rowsClasses = ParseRows(rows, table);
                hardwareObjectData.AddTableData(table, rowsClasses);
            }
            return hardwareObjectData;
        }

        // Returns all display fields data for the rows provided
        private static List<ComputerSystemHardwareData> ParseRows(ManagementObjectCollection rows, ComputerSystemHardwareClassEnum tableName)
        {
            List<ComputerSystemHardwareData> rowsClasses = new();
            try
            {
                foreach (ManagementObject row in rows)
                {
                    Dictionary<string, string> rowDisplayFieldData = new();
                    foreach (string field in ComputerSystemHardwareClassService.GetDisplayFields(tableName))
                    {
                        try
                        {
                            rowDisplayFieldData.Add(field, (string)row[field]);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    rowsClasses.Add(new ComputerSystemHardwareData(rowDisplayFieldData));
                }
            }
            catch (System.Management.ManagementException)
            {
                // Handle Version depend class object exceptions (invalid class exception for Win32_FloppyDrive)
            }
            return rowsClasses;
        }
    }
}
