using System.Management;
using WindowsHardwareFinder.model.repo;

namespace WindowsHardwareFinder.viewmodel.service.repo
{
    //Operates on and provides information about ComputerSystemHardware related tables
    //Contains useful information about how to operate on tables ComputerSystemHardware tables
    internal class ComputerSystemHardwareClassService : ComputerSystemHardwareMetadataData
    {

        /// <summary>
        /// Confirms if a column exists in a table and links the data to the table
        /// </summary>
        /// <param name="table">The table to search in for the column</param>
        /// <param name="column">The case insensitive name of the column</param>
        /// <returns>Returns a bool of whether or not the column is in that table</returns>
        public static bool TableHasProperty(ComputerSystemHardwareClassEnum tableName, string column)
        {
            PopulateFieldsIfEmpty(tableName);
            return AvailibleFields[tableName].Contains(column.ToLower()); ;
        }

        // Checks if the table's column names are already stored
        // Populates the data if none exists
        private static void PopulateFieldsIfEmpty(ComputerSystemHardwareClassEnum tableName)
        {
            if (!AvailibleFields.ContainsKey(tableName))
            {
                var wmiClass = new ManagementClass(tableName.ToString());
                List<string> availibleFields = new();
                foreach (var prop in wmiClass.Properties)
                {
                    availibleFields.Add(prop.Name.ToLower());
                }
                AvailibleFields.Add(tableName, availibleFields);
                //todo filter from input values
                DisplayFields.Add(tableName, availibleFields);
            }
        }

        public static List<string> GetDisplayFields(ComputerSystemHardwareClassEnum tableName)
        {
            PopulateFieldsIfEmpty(tableName);
            return DisplayFields[tableName];
        }


    }
}
