using System;
using System.Threading;
using System.Windows.Forms;
using DesktopClient.Tests.Automation.Helper;
using DesktopClient.Tests.Helper;
using DesktopClient.View;

namespace DesktopClient.Tests.Automation.Driver
{
    internal class MainWindowDriver
    {
        private MainWindow mainWindow;
        private AppUnhandledExceptionHelper appUnhandledExceptionHelper;

        public void StartMainWindowIfNecessary()
        {
            if (mainWindow != null)
                return;

            var mainWindowShownWaitHandle = new AutoResetEvent(false);
            ShowMainWindowAsync(mainWindowShownWaitHandle);
            WaitForMainWindowToBeShown(mainWindowShownWaitHandle);
        }

        public void CloseMainWindowIfNecessary()
        {
            if (mainWindow == null)
                return;

            UiHelper.DoOnUiThreadSync(mainWindow, () => mainWindow.Close());
            mainWindow = null;
        }

        public bool ClickNewOrderButton(int timeoutInMillis, out NewOrderFormDriver newOrderFormDriver)
        {
            var mainWindowNewOrderButtonDriver = new MainWindowNewOrderButtonDriver(mainWindow);
            return mainWindowNewOrderButtonDriver.ClickAndWaitForNewOrderForm(timeoutInMillis, out newOrderFormDriver);
        }

        public void ClickThrowExceptionButton()
        {
            UiHelper.DoOnUiThreadAsync(mainWindow, () => mainWindow.ThrowExceptionButton.PerformClick());
        }

        public bool CheckGridHasRow(params Func<DataGridViewRow, bool>[] rowPredicates)
        {
            var mainWindowGridDriver = new MainWindowGridDriver(mainWindow);
            return mainWindowGridDriver.CheckGridHasRow(rowPredicates);
        }

        public Exception RetrieveUnhandledException()
        {
            return appUnhandledExceptionHelper.RetrieveAndReset();
        }

        private void ShowMainWindowAsync(EventWaitHandle mainWindowShownWaitHandle)
        {
            // Don't use threadpool (directly or indirectly, e.g. via Task.Run).
            // If the threadpool is used, then the same thread could be used to start the main window
            // more than once. This will cause an exception in the various Application.Xyz calls.
            var thread = new Thread(() => StartMainWindow(mainWindowShownWaitHandle))
            {
                IsBackground = true,
                Name = "MainWindowUiThread"
            };
            thread.Start();
        }

        private void StartMainWindow(EventWaitHandle mainWindowShownWaitHandle)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            appUnhandledExceptionHelper = new AppUnhandledExceptionHelper();
            Application.ThreadException += appUnhandledExceptionHelper.OnUiThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += appUnhandledExceptionHelper.OnNonUiThreadsException;

            mainWindow = new MainWindow();
            mainWindow.Shown += (s, e) => mainWindowShownWaitHandle.Set();
            Application.Run(mainWindow);
        }

        private void WaitForMainWindowToBeShown(WaitHandle mainWindowShownWaitHandle)
        {
            mainWindowShownWaitHandle.WaitOne(2*1000);
        }

    }
}