
using System;

namespace OrdersApp
{
    class Program
    {
        static readonly List<Order> orders = new List<Order>();
        static readonly OrderService orderService = new OrderService(orders);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. create sample order\n2. send to warehouse\n3. send to shipping\n4. view orders\n5. exit");
                Console.Write("choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int option) || option < 1 || option > 5)
                {
                    Console.WriteLine("please enter a valid option (1-5).");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        orderService.CreateSampleOrder();
                        Console.WriteLine("sample order created.");
                        break;
                    case 2:
                        if (orders.Count == 0) Console.WriteLine("no orders available.");
                        else 
                        { 
                            if (orderService.SendToWarehouse(orders[0]))
                                Console.WriteLine("order sent to warehouse."); 
                            else
                                Console.WriteLine("failed to send to warehouse.");
                        }
                        break;
                    case 3:
                        if (orders.Count == 0) Console.WriteLine("no orders available.");
                        else
                        {
                            if (orderService.SendToShipping(orders[0]))
                                Console.WriteLine("order shipped and closed.");
                            else
                                Console.WriteLine("failed to send to shipping.");
                        }
                        break;
                    case 4:
                        var ordersList = orderService.GetOrders();
                        if (ordersList.Count == 0) Console.WriteLine("no orders available.");
                        else foreach (var order in ordersList) Console.WriteLine($"product: {order.ProductName}, amot: {order.Amount}, status: {order.Status}");
                        break;
                    case 5:
                        return;
                }
            }
        }
    }
}