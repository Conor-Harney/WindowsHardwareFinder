using System.Windows;
using WindowsHardwareFinder.viewmodel.viewManager;

namespace WindowsHardwareFinder.view
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DeviceInfoManager.CurrentWindow = this;
            viewList.ItemsSource = DeviceInfoManager.GetActivatedTablesMenu();
            DeviceInfoManager.ScheduleWindowUpdate();
        }
    }
}