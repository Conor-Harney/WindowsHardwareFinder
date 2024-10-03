using System.Management;
using WindowsHardwareFinder.model.repo;

namespace WindowsHardwareFinder.viewmodel.util
{
    internal class HardwareTableInfoUtil : HardwareTableInfo
    {
        public static bool tableHasProperty(ManagementObjectCollection rows, ComputerSystemHardwareClass table, string property)
        {
            if(rows.Count == 0) return false;
            PopulateIfInfoNotExists(rows, table);
            bool propertyPresent = TableFields[table].Contains(property.ToLower());
            return propertyPresent;
        }

        private static void PopulateIfInfoNotExists(ManagementObjectCollection rows, ComputerSystemHardwareClass table)
        {
            if (!TableFields.ContainsKey(table))
            {
                foreach (ManagementObject row in rows)
                {
                    PopulateIfInfoNotExists(row, table);
                    break;
                }
            }
        }

        private static void PopulateIfInfoNotExists(ManagementObject row, ComputerSystemHardwareClass table)
        {
            if (!TableFields.ContainsKey(table))
            {
                List<string> availibleProperties = new List<string>();
                foreach (PropertyData propertyData in row.Properties)
                {
                    availibleProperties.Add(propertyData.Name.ToLower());
                }
                TableFields.Add(table, availibleProperties);
            }
        }

        public static IReadOnlyCollection<HardwareObject> GetActivatedTables()
        {
            return HardwareObjectRelatedTables.Keys;
        }

        public static List<ComputerSystemHardwareClass> GetTablesForObject(HardwareObject hardwareObject)
        {
            return HardwareObjectRelatedTables.GetValueOrDefault(hardwareObject);
        }
    }
}
