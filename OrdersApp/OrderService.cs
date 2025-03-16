// OrderService.cs
namespace OrdersApp
{
    public class OrderService
    {
        private readonly List<Order> orders;

        public OrderService(List<Order> orders)
        {
            this.orders = orders;
        }

        public void CreateOrderFromInput()
        {
            Console.WriteLine("\nenter order details:");

            decimal amount;
            while (true)
            {
                Console.Write("amount: ");
                if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
                    break;
                Console.WriteLine("invalid amount, please enter a positive number.");
            }

            string productName;
            while (true)
            {
                Console.Write("product name: ");
                productName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(productName))
                    break;
                Console.WriteLine("product name cant be empty.");
            }

            ClientType clientType;
            while (true)
            {
                Console.Write("client Type (1 = individual, 2 = company): ");
                if (int.TryParse(Console.ReadLine(), out int type) && (type == 1 || type == 2))
                {
                    clientType = (ClientType)type;
                    break;
                }
                Console.WriteLine("invalid choice, choose either 1 or 2.");
            }

            string deliveryAddress;
            while (true)
            {
                Console.Write("delivery address: ");
                deliveryAddress = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(deliveryAddress))
                    break;
                Console.WriteLine("delivery address cannot be empty");
            }

            PaymentMethod paymentMethod;
            while (true)
            {
                Console.Write("payment method (1 = card, 2 = cash on delivery): ");
                if (int.TryParse(Console.ReadLine(), out int method) && (method == 1 || method == 2))
                {
                    paymentMethod = (PaymentMethod)method;
                    break;
                }
                Console.WriteLine("invalid choice, choose either 1 or 2");
            }

            var order = new Order(amount, productName, clientType, deliveryAddress, paymentMethod);
            orders.Add(order);
            Console.WriteLine("order created successfully!");
        }

        public void CreateSampleOrder()
        {
            var order = new Order(1000m, "laptop", ClientType.Individual, "15 ulica", PaymentMethod.Card);
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