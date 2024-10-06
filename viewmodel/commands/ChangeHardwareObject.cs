using System.Windows.Input;
using WindowsHardwareFinder.model.view;
using WindowsHardwareFinder.viewmodel.viewManager;

namespace WindowsHardwareFinder.modelView.commands
{
    internal class ChangeHardwareObject : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return Enum.TryParse((string?)parameter, out HardwareObjectEnum hardwareObject);
        }

        public void Execute(object? parameter)
        {
            if (Enum.TryParse((string?)parameter, out HardwareObjectEnum hardwareObject))
            {
                DeviceInfoManager.CurrentHardwareObject = hardwareObject;
                DeviceInfoManager.UpdateWindow();
            }
        }
    }
}
