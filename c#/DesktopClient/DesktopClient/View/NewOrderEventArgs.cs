using System;
using DesktopClient.Model;

namespace DesktopClient.View
{
    public class NewOrderEventArgs : EventArgs
    {
        public IOrder Order { get; set; }

        public NewOrderEventArgs(IOrder order)
        {
            Order = order;
        }
    }
}