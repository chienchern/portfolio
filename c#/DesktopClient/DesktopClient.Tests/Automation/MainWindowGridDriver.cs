using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DesktopClient.Tests.Helper;
using DesktopClient.View;

namespace DesktopClient.Tests.Automation
{
    internal class MainWindowGridDriver
    {
        private readonly MainWindow mainWindow;

        public MainWindowGridDriver(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public bool CheckGridHasRow(Func<DataGridViewRow, bool>[] rowPredicates)
        {
            var result = false;
            var gridRowsCheckedWaitHandle = new AutoResetEvent(false);

            UiHelper.DoOnUiThreadAsync(mainWindow, () =>
            {
                result = CheckGridHasRowMatching(rowPredicates);
                gridRowsCheckedWaitHandle.Set();
            });

            Wait.For(gridRowsCheckedWaitHandle, 1 * 1000);
            return result;
        }

        private bool CheckGridHasRowMatching(Func<DataGridViewRow, bool>[] rowPredicates)
        {
            foreach (DataGridViewRow row in mainWindow.Grid.Rows)
            {
                if (rowPredicates.All(rp => rp(row)))
                    return true;
            }

            return false;
        }
    }
}