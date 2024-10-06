using WindowsHardwareFinder.model.repo;
using WindowsHardwareFinder.model.view;

namespace WindowsHardwareFinder.viewmodel.service.view
{
    internal class HardwareObjectService : HardwareObjectMetadataData
    {
        // Activated Hardware Objects are Hardware Objects that have tables associated with them 
        public static IReadOnlyCollection<HardwareObjectEnum> GetAvailibleHardwareObjects()
        {
            return HardwareObjectRelatedTables.Keys;
        }

        // Returns A list of tables associated with a Hardware Object or an empty list if data about that object hasn't been populated.
        public static List<ComputerSystemHardwareClassEnum> GetTablesForObject(HardwareObjectEnum hardwareObject)
        {
            List<ComputerSystemHardwareClassEnum>? classes = HardwareObjectRelatedTables.GetValueOrDefault(hardwareObject);
            if (null == classes)
            {
                return new List<ComputerSystemHardwareClassEnum>();
            }
            return classes;
        }
    }
}
