using System;
using System.ComponentModel;

namespace DesktopClient.Tests.Helper
{
    public static class UiHelper
    {
        public static void DoOnUiThreadAsync(ISynchronizeInvoke synchronizeInvoke, Action action)
        {
            if (synchronizeInvoke.InvokeRequired)
            {
                synchronizeInvoke.BeginInvoke(action, null);
                return;
            }

            action();
        }

        public static void DoOnUiThreadSync(ISynchronizeInvoke synchronizeInvoke, Action action)
        {
            if (synchronizeInvoke.InvokeRequired)
            {
                synchronizeInvoke.Invoke(action, null);
                return;
            }

            action();
        }
    }
}