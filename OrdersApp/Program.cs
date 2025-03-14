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
                    case "5":
                        return;
                    default:
                        Console.WriteLine("invalid option.");
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
    }
}