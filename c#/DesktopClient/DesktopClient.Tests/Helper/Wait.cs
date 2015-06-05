using System.Threading;

namespace DesktopClient.Tests.Helper
{
    internal static class Wait
    {
        public static bool For(WaitHandle waitHandle, int timeoutInMillis)
        {
            return waitHandle.WaitOne(timeoutInMillis);
        }
    }
}