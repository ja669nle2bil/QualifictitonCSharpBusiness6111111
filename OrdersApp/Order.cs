// Główna klasa dla Zamówień.
namespace OrdersApp
{
    public class Order
    {
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public ClientType ClientType { get; set; }
        public string DeliveryAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }

        public Order(decimal amount, string productName, ClientType clientType, string deliveryAddress, PaymentMethod paymentMethod)
        {
            Amount = amount;
            ProductName = productName;
            ClientType = clientType;
            DeliveryAddress = deliveryAddress;
            PaymentMethod = paymentMethod;
            Status = OrderStatus.New;
        }
    }
}