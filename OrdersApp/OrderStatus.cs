// Klasa z Enumami dla: Statusu zamowienia.
namespace OrdersApp
{
    public enum OrderStatus
    {
        New = 1,
        InWarehouse = 2,
        InShipping = 3,
        ReturnedToClient = 4,
        Error = 5,
        Closed = 6
    }
}