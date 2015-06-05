using System.Threading;

namespace DesktopClient.Tests.Automation
{
    internal static class TestSerializer
    {
        private static readonly AutoResetEvent testRunningWaitHandle = new AutoResetEvent(true);
        
        public static void WaitToRunTest()
        {
            testRunningWaitHandle.WaitOne();
        }

        public static void FinishRunningTest()
        {
            testRunningWaitHandle.Set();
        }
    }
}