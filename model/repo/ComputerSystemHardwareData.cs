namespace WindowsHardwareFinder.model.repo
{
    //ref https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/computer-system-hardware-classes
    
    internal record ComputerSystemHardwareData
    {
        public ComputerSystemHardwareData(Dictionary<string, string> Fields) 
        {
            this.Fields = Fields;
        }
        protected Dictionary<string, string> Fields = new();
        public Dictionary<string, string> GetFields()
        {
            return this.Fields;
        }
    }
}
