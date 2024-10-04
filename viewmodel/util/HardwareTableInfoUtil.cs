using System.Management;
using WindowsHardwareFinder.model.repo;

namespace WindowsHardwareFinder.viewmodel.util
{
    //Operates on and provides information about Hardware related tables
    //Contains useful information about how to operate on tables Hardware tables
    internal class HardwareTableInfoUtil : HardwareTableInfo
    {
        /// <summary>
        /// Confirms if a column exists in a table and links the data to the table
        /// </summary>
        /// <param name="table">The table to search in for the column</param>
        /// <param name="column">The case insensitive name of the column</param>
        /// <returns>Returns a bool of whether or not the column is in that table</returns>
        public static bool TableHasProperty(ComputerSystemHardwareClass table, string column)
        {
            PopulateIfInfoNotExists(table);
            return TableFields[table].Contains(column.ToLower()); ;
        }

        // Checks if the table's column names are already stored
        // Populates the data if none exists
        private static void PopulateIfInfoNotExists(ComputerSystemHardwareClass table)
        {
            if (!TableFields.ContainsKey(table))
            {
                var wmiClass = new ManagementClass(table.ToString());
                List<string> availibleProperties = new();
                foreach (var prop in wmiClass.Properties)
                {
                    availibleProperties.Add(prop.Name.ToLower());
                }
                TableFields.Add(table, availibleProperties);
            }
        }

        // Activated Hardware Objects are Hardware Objects that have tables associated with them 
        public static IReadOnlyCollection<HardwareObject> GetAvailibleHardwareObjects()
        {
            return HardwareObjectRelatedTables.Keys;
        }

        // Returns A list of tables associated with a Hardware Object or an empty list if data about that object hasn't been populated.
        public static List<ComputerSystemHardwareClass> GetTablesForObject(HardwareObject hardwareObject)
        {
            List<ComputerSystemHardwareClass>? classes = HardwareObjectRelatedTables.GetValueOrDefault(hardwareObject);
            if (null  == classes)
            {
                return new List<ComputerSystemHardwareClass>();
            }
            return classes;
        }
    }
}
