using System;
using System.Collections.Generic;
using OrdersApp;

namespace OrderProcessingApp
{
    class Program
    {
        static List<Order> orders = new List<Order>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. create sample order\n2. send to warehouse\n3. send to shipping\n4. view orders\n5. exit");
                Console.Write("choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateSampleOrder();
                        break;
                    case "2":
                        SendToWarehouse();
                        break;
                    case "3":
                        SendToShipping();
                        break;
                    case "4":
                        ViewOrders();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        static void CreateSampleOrder()
        {
            var order = new Order(1000m, "laptop", ClientType.Individual, "15 ulica", PaymentMethod.Card);
            orders.Add(order);
            Console.WriteLine("sample order created.");
        }
        static void SendToWarehouse()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("no orders available.");
                return;
            }

            var order = orders[0];
            if (string.IsNullOrEmpty(order.DeliveryAddress))
            {
                order.Status = OrderStatus.Error;
                Console.WriteLine("order has no delivery address. error.");
            }
            else if (order.Amount >= 2500m && order.PaymentMethod == PaymentMethod.CashOnDelivery)
            {
                order.Status = OrderStatus.ReturnedToClient;
                Console.WriteLine("order over 2500 with cash on delivery. returned.");
            }
            else
            {
                order.Status = OrderStatus.InWarehouse;
                Console.WriteLine("order sent to warehouse.");
            }
        }

        static void SendToShipping()
        {
            if (orders.Count == 0 || orders[0].Status != OrderStatus.InWarehouse)
            {
                Console.WriteLine("no orders in warehouse.");
                return;
            }

            var order = orders[0];
            order.Status = OrderStatus.InShipping;
            Console.WriteLine("order sent to shipping. wait");
            Thread.Sleep(5000); // Simulate 5-second delay
            order.Status = OrderStatus.Closed;
            Console.WriteLine("order shipped & closed.");
        }

        static void ViewOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("no orders available.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine($"product: {order.ProductName}, amount: {order.Amount}, status: {order.Status}");
            }
        }
    }
}