using System.Reactive.Linq;
using WindowsHardwareFinder.model.repo;
using WindowsHardwareFinder.model.view;
using WindowsHardwareFinder.view;
using WindowsHardwareFinder.view.parser;
using WindowsHardwareFinder.viewmodel.service.view;
using static WindowsHardwareFinder.model.menu.LeafMenu;

namespace WindowsHardwareFinder.viewmodel.viewManager
{
    public class DeviceInfoManager
    {
        public static MainWindow? CurrentWindow { get; set; }

        public static HardwareObjectEnum CurrentHardwareObject { get; set; }

        private static IObservable<long> oneSecondEvents = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(1));
        private static IObservable<long> tenSecondEvents = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(10));
        private static IObservable<long> oneMinuteEvents = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromMinutes(1));
        private static Dictionary<ComputerSystemHardwareClassEnum, Dictionary<string, Dictionary<string, string>>> HardwareData = new();
        internal static void ScheduleWindowUpdate()
        {
            if (null != CurrentWindow)
            {
                oneSecondEvents.Subscribe(static e =>
                {
                    CurrentWindow.Dispatcher.Invoke(() =>
                    {
                        CurrentWindow.tableDataCollection.ItemsSource = HardwareData;
                        CurrentWindow.tbLastUpdated.Text = DateTimeOffset.Now.ToString();
                    });
                });

                oneMinuteEvents.Subscribe(e =>
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
            HardwareData = HardwareTableParser.MapData(CurrentHardwareObject);
        }

        public static IEnumerable<LeafMenuItem> GetActivatedTablesMenu()
        {
            return HardwareObjectService.GetAvailibleHardwareObjects().Select(view => new LeafMenuItem(view.ToString()));
        }
    }
}
