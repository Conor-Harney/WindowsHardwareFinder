using System.Management;
using WindowsHardwareFinder.model.repo;
using WindowsHardwareFinder.model.user;
using WindowsHardwareFinder.modelView.repo;
using WindowsHardwareFinder.viewmodel.util;

namespace WindowsHardwareFinder.view.parser
{
    internal static class HardwareTableParser
    {
        public static string UserFriendlyTable(HardwareObject hardwareObject)
        {
            HardwareObjectData hardwareObjectData = ParseHardwareObject(hardwareObject);
            String data = hardwareObjectData.Name + ":\r\n";
            foreach (ComputerSystemHardwareClassData classData in hardwareObjectData.ComputerSystemHardwareClasses)
            {
                data += "\t" + classData.Name + ":\r\n";
                foreach (string description in classData.Descriptions)
                {
                    data += "\t\t" + description + "\r\n";
                }
            }
            return data;
        }
        
        public static HardwareObjectData ParseHardwareObject(HardwareObject hardwareObject) 
        {
            HardwareObjectData hardwareObjectData = new HardwareObjectData(hardwareObject);
            foreach (ComputerSystemHardwareClass table in HardwareTableInfoUtil.GetTablesForObject(hardwareObject))
            {
                ManagementObjectCollection rows = HardwareObjectRepo.queryAll(table);
                ComputerSystemHardwareClassData computerSystemHardwareClassData = ParseRows(rows, table);
                hardwareObjectData.ComputerSystemHardwareClasses.Add(computerSystemHardwareClassData);
            }
            return hardwareObjectData;
        }

        private static ComputerSystemHardwareClassData ParseRows(ManagementObjectCollection rows, ComputerSystemHardwareClass computerSystemHardwareClass)
        {
            string fieldToFind = "Description";
            ComputerSystemHardwareClassData computerSystemHardwareClassData = new ComputerSystemHardwareClassData(computerSystemHardwareClass);
            if (HardwareTableInfoUtil.TableHasProperty( computerSystemHardwareClass, fieldToFind))
            {
                foreach (ManagementObject row in rows)
                {

                    try
                    {
                        var description = row[fieldToFind];
                        computerSystemHardwareClassData.Descriptions.Add((string)description);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return computerSystemHardwareClassData;
        }
    }
}
