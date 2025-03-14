// OrderService.cs (new file in OrderProcessingApp)
namespace OrdersApp
{
    public class OrderService
    {
        private readonly List<Order> orders;

        public OrderService(List<Order> orders)
        {
            this.orders = orders;
        }

        public void CreateSampleOrder()
        {
            var order = new Order(1000m, "laptop", ClientType.Individual, "13 ulica", PaymentMethod.Card);
            orders.Add(order);
        }

        public bool SendToWarehouse(Order order)
        {
            if (string.IsNullOrEmpty(order.DeliveryAddress))
            {
                order.Status = OrderStatus.Error;
                return false;
            }
            if (order.Amount >= 2500m && order.PaymentMethod == PaymentMethod.CashOnDelivery)
            {
                order.Status = OrderStatus.ReturnedToClient;
                return false;
            }
            order.Status = OrderStatus.InWarehouse;
            return true;
        }

        public bool SendToShipping(Order order)
        {
            if (order.Status != OrderStatus.InWarehouse)
            {
                return false;
            }
            order.Status = OrderStatus.InShipping;
            Thread.Sleep(5000); 
            order.Status = OrderStatus.Closed;
            return true;
        }

        public List<Order> GetOrders() => orders;
    }
}