using System;
using System.Windows.Forms;
using DesktopClient.ViewModel;

namespace DesktopClient.View
{
    public partial class NewOrderForm : Form
    {
        private readonly INewOrderFormViewModel newOrderFormViewModel;
        
        public NewOrderForm(INewOrderFormViewModel newOrderFormViewModel)
        {
            InitializeComponent();
            buttonSubmit.Click += ButtonSubmitOnClick;
            
            this.newOrderFormViewModel = newOrderFormViewModel;
        }

        public Button SubmitButton
        {
            get { return buttonSubmit; }
        }

        public void Populate(string client, string product, string quantity)
        {
            //TODO: Make properties; can also be used in test?
            textBoxClient.Text = client;
            textBoxProduct.Text = product;
            textBoxQuantity.Text = quantity;
        }

        private void ButtonSubmitOnClick(object sender, EventArgs eventArgs)
        {
            var client = textBoxClient.Text;
            var product = textBoxProduct.Text;
            var quantity = textBoxQuantity.Text;

            newOrderFormViewModel.SubmitOrder(client, product, quantity);
            Close();
        }
    }
}
