using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopClient.Tests.Automation.Helper
{
    internal class AppUnhandledExceptionHelper
    {
        private Exception nonUiThreadException;
        private Exception uiThreadException;

        public Exception RetrieveAndReset()
        {
            Task.Delay(2 * 1000).Wait();

            var result = nonUiThreadException ?? uiThreadException;
            Reset();

            return result;
        }

        public void OnNonUiThreadsException(object sender, UnhandledExceptionEventArgs e)
        {
            nonUiThreadException = (Exception)e.ExceptionObject;
        }

        public void OnUiThreadException(object sender, ThreadExceptionEventArgs e)
        {
            uiThreadException = e.Exception;
        }

        private void Reset()
        {
            nonUiThreadException = null;
            uiThreadException = null;
        }
    }
}