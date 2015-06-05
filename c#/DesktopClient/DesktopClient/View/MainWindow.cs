using System;
using System.Windows.Forms;
using DesktopClient.ViewModel;

namespace DesktopClient.View
{
    public partial class MainWindow : Form
    {
        public EventHandler NewOrderFormShown = delegate { };
        private readonly IMainWindowViewModel mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();

            // TODO: Use Autofac
            mainWindowViewModel = new MainWindowViewModel(() => new NewOrderFormViewModel());
            dataGridViewOrders.DataSource = mainWindowViewModel.Orders;
        }

        public Button NewOrderButton { get { return buttonNewOrder; } }
        public Button ThrowExceptionButton { get { return buttonThrowException; } }
        public DataGridView Grid { get { return dataGridViewOrders; } }

        private void OnButtonNewOrderClick(object sender, EventArgs args)
        {
            var newOrderFormViewModel = mainWindowViewModel.GetNewOrderFormViewModel();
            var newOrderForm = new NewOrderForm(newOrderFormViewModel) { StartPosition = FormStartPosition.CenterParent };
            newOrderForm.Shown += (s, e) => NewOrderFormShown(s, e);
            newOrderForm.ShowDialog(this);
        }

        private void OnButtonThrowExceptionClick(object sender, EventArgs e)
        {
            throw new Exception("'Throw Exception' button was clicked.");
        }
    }
}
