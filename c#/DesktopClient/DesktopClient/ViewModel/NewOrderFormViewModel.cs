using System;
using DesktopClient.Model;
using DesktopClient.View;

namespace DesktopClient.ViewModel
{
    public class NewOrderFormViewModel : INewOrderFormViewModel
    {
        public event EventHandler<NewOrderEventArgs> OrderSubmitted = delegate { };

        public void SubmitOrder(string customer, string product, string quantity)
        {
            var id = Guid.NewGuid().ToString();
            var order = new Order(customer, id, product, quantity);
            // Note: In a real system, this will enrich + post to server (which will persist) + etc before raising the event

            OrderSubmitted(this, new NewOrderEventArgs(order));
        }
    }
}