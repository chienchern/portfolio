using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesktopClient.Model
{
    public class Order : IOrder, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string customer;
        private string id;
        private string product;
        private string quantity;

        public Order(string customer, string id, string product, string quantity)
        {
            this.customer = customer;
            this.id = id;
            this.product = product;
            this.quantity = quantity;
        }

        public string Customer
        {
            get { return customer; }
            set { SetValue(ref customer, value); }
        }

        public string Id
        {
            get { return id; }
            set { SetValue(ref id, value); }
        }

        public string Product
        {
            get { return product; }
            set { SetValue(ref product, value); }
        }

        public string Quantity
        {
            get { return quantity; }
            set { SetValue(ref quantity, value); }
        }

        private void SetValue<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (Equals(currentValue, newValue)) 
                return;
            
            currentValue = newValue;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}