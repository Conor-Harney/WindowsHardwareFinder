using System.Management;
using WindowsHardwareFinder.model.repo;

namespace WindowsHardwareFinder.modelView.repo
{
    internal class HardwareObjectRepo
    {
        //operates on a Management Object Searcher to retreive collections of "management objects"
        //ref: https://learn.microsoft.com/en-us/dotnet/api/system.management.managementobjectsearcher?view=net-6.0
        public static ManagementObjectCollection queryAll(ComputerSystemHardwareClass table)
        {
            string query = String.Format("SELECT * FROM {0}", table);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", query);
            ManagementObjectCollection rows = searcher.Get();
            return rows;
        }
    }
}
