using System;
using System.ComponentModel;
using DesktopClient.Model;
using DesktopClient.View;

namespace DesktopClient.ViewModel
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly Func<INewOrderFormViewModel> newOrderFormViewModelFactory;
        private readonly BindingList<IOrder> orders;

        public MainWindowViewModel(Func<INewOrderFormViewModel> newOrderFormViewModelFactory)
        {
            this.newOrderFormViewModelFactory = newOrderFormViewModelFactory;
            orders = new BindingList<IOrder>();
        }

        public BindingList<IOrder> Orders
        {
            get { return orders; }
        }

        public INewOrderFormViewModel GetNewOrderFormViewModel()
        {
            var newOrderFormViewModel = newOrderFormViewModelFactory();
            newOrderFormViewModel.OrderSubmitted += OnNewOrderSubmitted;

            return newOrderFormViewModel;
        }

        private void OnNewOrderSubmitted(object sender, NewOrderEventArgs args)
        {
            orders.Add(args.Order);
        }
    }
}