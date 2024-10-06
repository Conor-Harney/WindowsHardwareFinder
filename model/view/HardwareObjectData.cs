using WindowsHardwareFinder.model.repo;

namespace WindowsHardwareFinder.model.view
{
    internal record HardwareObjectData
    {   
        public string Name { get; }
        private Dictionary<ComputerSystemHardwareClassEnum, List<ComputerSystemHardwareData>> ComputerSystemHardwareClassData;

        public HardwareObjectData(HardwareObjectEnum Name)
        {
            this.Name = Name.ToString();
            ComputerSystemHardwareClassData = new();
        }
        public void AddTableData(ComputerSystemHardwareClassEnum tableName, List<ComputerSystemHardwareData> data)
        {
            ComputerSystemHardwareClassData.Add(tableName, data);
        }

        public IReadOnlyDictionary<ComputerSystemHardwareClassEnum, List<ComputerSystemHardwareData>> GetComputerSystemHardwareClassData()
        {
            return ComputerSystemHardwareClassData;
        }
    }
}
