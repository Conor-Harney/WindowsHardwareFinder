using WindowsHardwareFinder.model.repo;

namespace WindowsHardwareFinder.model.user
{
    internal record HardwareObjectData
    {
        public HardwareObjectData(HardwareObject Name) 
        {
            this.Name = Name.ToString();
            this.ComputerSystemHardwareClasses = new List<ComputerSystemHardwareClassData>();
        }
        public string Name { get; }
        public List<ComputerSystemHardwareClassData> ComputerSystemHardwareClasses { get; set; }
    }

    internal record ComputerSystemHardwareClassData
    {
        public ComputerSystemHardwareClassData(ComputerSystemHardwareClass Name)
        {
            this.Name = Name.ToString();
            this.Descriptions = new List<string>();
        }
        public string Name { get; }
        public List<string> Descriptions { get; set; }
    }
}
