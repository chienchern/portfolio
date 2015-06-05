using System.ComponentModel;
using DesktopClient.Model;

namespace DesktopClient.ViewModel
{
    public interface IMainWindowViewModel
    {
        INewOrderFormViewModel GetNewOrderFormViewModel();
        BindingList<IOrder> Orders { get; }
    }
}