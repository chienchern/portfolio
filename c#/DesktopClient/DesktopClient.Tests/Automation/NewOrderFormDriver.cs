using System.Threading;
using DesktopClient.Tests.Helper;
using DesktopClient.View;

namespace DesktopClient.Tests.Automation
{
    internal class NewOrderFormDriver
    {
        private readonly NewOrderForm newOrderForm;
        private readonly AutoResetEvent newOrderFormClosedWaitHandle;

        public NewOrderFormDriver(NewOrderForm newOrderForm)
        {
            this.newOrderForm = newOrderForm;

            newOrderFormClosedWaitHandle = new AutoResetEvent(false);
            newOrderForm.Closed += (sender, args) => newOrderFormClosedWaitHandle.Set();
        }

        public void Populate(string customer, string product, string quantity)
        {
            UiHelper.DoOnUiThreadAsync(newOrderForm, () =>
            {
                newOrderForm.Populate(customer, product, quantity);
            });
        }

        public void SubmitOrder()
        {
            UiHelper.DoOnUiThreadAsync(newOrderForm, () => newOrderForm.SubmitButton.PerformClick());
        }

        public bool WaitForNewOrderFormToBeClosed(int timeOutInMillis)
        {
            return Wait.For(newOrderFormClosedWaitHandle, timeOutInMillis);
        }
    }
}