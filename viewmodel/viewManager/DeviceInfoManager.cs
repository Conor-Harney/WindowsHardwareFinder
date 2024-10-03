using System.Reactive.Linq;
using WindowsHardwareFinder.model.repo;
using WindowsHardwareFinder.model.user;
using WindowsHardwareFinder.view;
using WindowsHardwareFinder.view.parser;
using WindowsHardwareFinder.viewmodel.util;
using static WindowsHardwareFinder.model.menu.LeafMenu;

namespace WindowsHardwareFinder.viewmodel.viewManager
{
    public class DeviceInfoManager
    {
        public static MainWindow? CurrentWindow { get; set; }

        public static HardwareObject CurrentHardwareObject { get; set; }

        private static IObservable<long> OneSecondEvents = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(1));
        private static IObservable<long> TenSecondEvents = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(10));
        private static string HardwareData = "";
        internal static void ScheduleWindowUpdate()
        {
            if (null != CurrentWindow)
            {
                OneSecondEvents.Subscribe(e =>
                {
                    CurrentWindow.Dispatcher.Invoke(() =>
                    {
                        CurrentWindow.tbDeviceInfo.Text = HardwareData;
                        CurrentWindow.tbLastUpdated.Text = DateTimeOffset.Now.ToString();
                    });
                });

                TenSecondEvents.Subscribe(e =>
                {
                    CurrentWindow.Dispatcher.Invoke(() =>
                    {
                        UpdateWindow();
                    });
                });
            }
        }

        public static void UpdateWindow()
        {
            string data = "";
            HardwareObjectData hardwareObjectData = HardwareTableParser.ParseHardwareObject(CurrentHardwareObject);
            data += HardwareTableParser.UserFriendlyTable(CurrentHardwareObject);
            HardwareData = data;
        }

        public static IEnumerable<LeafMenuItem> GetActivatedTablesMenu()
        {
            return HardwareTableInfoUtil.GetActivatedTables().Select(view => new LeafMenuItem(view.ToString()));
        }
    }
}
