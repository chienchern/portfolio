using System;
using DesktopClient.View;

namespace DesktopClient.ViewModel
{
    public interface INewOrderFormViewModel
    {
        event EventHandler<NewOrderEventArgs> OrderSubmitted;
        void SubmitOrder(string customer, string product, string quantity);
    }
}