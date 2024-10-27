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
        private const int MAX_TABLE_ENTRIES = 100000;
        public static Dictionary<ComputerSystemHardwareClassEnum, Dictionary<string, Dictionary<string, string>>> MapData(HardwareObjectEnum hardwareObjectName)
        {
            Dictionary<ComputerSystemHardwareClassEnum, Dictionary<string, Dictionary<string, string>>> hardwareObjectData = new();

            foreach (ComputerSystemHardwareClassEnum table in HardwareObjectService.GetTablesForObject(hardwareObjectName))
            {
                ManagementObjectCollection rows = HardwareObjectRepo.queryAll(table);
                try
                {
                    if (rows.Count > 0)
                    {
                        Dictionary<string, Dictionary<string, string>> tableEntries = ParseRows(rows, table);
                        hardwareObjectData.Add(table, tableEntries);
                    }
                }
                catch (System.Management.ManagementException)
                {
                    // Handle Version depend class object exceptions (invalid class exception for Win32_FloppyDrive)
                }
            }
            return hardwareObjectData;
            
        }
        
        // Returns all display fields data for the rows provided
        private static Dictionary<string, Dictionary<string, string>> ParseRows(ManagementObjectCollection rows, ComputerSystemHardwareClassEnum tableName)
        {
            Dictionary<string, Dictionary<string, string>> tableEntries = new();
            try
            {
                foreach (ManagementObject row in rows)
                {
                    if (rows.Count > 0)
                    {
                        Dictionary<string, string> fieldData = new();
                        foreach (string field in ComputerSystemHardwareClassService.GetDisplayFields(tableName))
                        {
                            try
                            {
                                string value = (string)row[field];
                                if (null != value)
                                {
                                    fieldData.Add(field, (string)row[field]);
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }

                        string itemName = genItemName(tableEntries.Keys.ToList(), fieldData, tableName.ToString());
                        tableEntries.Add(itemName, fieldData);
                        if (tableEntries.Count >= MAX_TABLE_ENTRIES) 
                        { 
                            break; 
                        }
                    }
                }
            }
            catch (System.Management.ManagementException)
            {
                // Handle Version depend class object exceptions (invalid class exception for Win32_FloppyDrive)
            }
            return tableEntries;
        }

        private static string genItemName(List<string> tableEntryKeys, Dictionary<string, string> fieldData, string tableName)
        {
            string prefix = fieldData.GetValueOrDefault("name", tableName.ToString());
            int keyOccurance = 1;
            while (tableEntryKeys.Contains(prefix + "_" + keyOccurance))
            { 
                keyOccurance++; 
            }
            string itemName = prefix + "_" + keyOccurance;
            return itemName;
        }
    }
}
