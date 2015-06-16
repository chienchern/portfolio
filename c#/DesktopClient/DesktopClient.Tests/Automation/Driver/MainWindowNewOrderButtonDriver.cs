using System.Threading;
using DesktopClient.Tests.Helper;
using DesktopClient.View;

namespace DesktopClient.Tests.Automation.Driver
{
    internal class MainWindowNewOrderButtonDriver
    {
        private readonly MainWindow mainWindow;

        public MainWindowNewOrderButtonDriver(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public bool ClickAndWaitForNewOrderForm(int timeoutInMillis, out NewOrderFormDriver newOrderFormDriver)
        {
            var newOrderFormShownWaitHandle = new AutoResetEvent(false);

            NewOrderForm newOrderForm = null;
            mainWindow.NewOrderFormShown += (sender, args) =>
            {
                newOrderForm = (NewOrderForm) sender;
                newOrderFormShownWaitHandle.Set();
            };

            UiHelper.DoOnUiThreadAsync(mainWindow, () => mainWindow.NewOrderButton.PerformClick());

            var isNewOrderFormShown = newOrderFormShownWaitHandle.WaitOne(timeoutInMillis);
            newOrderFormDriver = isNewOrderFormShown ? new NewOrderFormDriver(newOrderForm) : null;

            return isNewOrderFormShown;
        }
    }
}