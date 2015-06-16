namespace DesktopClient.Model
{
    public interface IOrder
    {
        string Customer { get; set; }
        string Id { get; set; }
        string Product { get; set; }
        string Quantity { get; set; }
    }
}