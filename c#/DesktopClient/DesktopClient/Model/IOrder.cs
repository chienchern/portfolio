namespace DesktopClient.Model
{
    public interface IOrder
    {
        string Customer { get; }
        string Id { get; }
        string Product { get; }
        string Quantity { get; }
    }
}