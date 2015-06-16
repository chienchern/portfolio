namespace DesktopClient.Model
{
    public interface IOrder
    {
        string Id { get; set; }
        string Customer { get; set; }
        string Product { get; set; }
        string Quantity { get; set; }
    }
}