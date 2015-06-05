using System.Windows.Forms;

namespace DesktopClient.Tests.Helper
{
    public static class DataGridViewRowHelper
    {
        public static string GetCustomerValue(DataGridViewRow row)
        {
            return GetValue(row, "Customer");
        }

        public static string GetProductValue(DataGridViewRow row)
        {
            return GetValue(row, "Product");
        }
        
        public static string GetQuantityValue(DataGridViewRow row)
        {
            return GetValue(row, "Quantity");
        }

        private static string GetValue(DataGridViewRow row, string columnHeader)
        {
            return row.Cells[columnHeader].Value.ToString();
        }
    }
}