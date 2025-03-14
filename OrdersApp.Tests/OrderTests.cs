// OrderTests.cs
using Xunit;
using OrdersApp;

namespace OrdersApp.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_Initialization_SetsPropertiesCorrectly()
        {
            var order = new Order(1000m, "laptop", ClientType.Individual, "13 ulica", PaymentMethod.Card);
            Assert.Equal(1000m, order.Amount);
            Assert.Equal("laptop", order.ProductName);
            Assert.Equal(ClientType.Individual, order.ClientType);
            Assert.Equal("13 ulica", order.DeliveryAddress);
            Assert.Equal(PaymentMethod.Card, order.PaymentMethod);
            Assert.Equal(OrderStatus.New, order.Status);
        }

        [Fact]
        public void SendToWarehouse_CashOnDeliveryOver2500_ReturnsToClient()
        {
            var orders = new List<Order>();
            var service = new OrderService(orders);
            var order = new Order(3000m, "speaker", ClientType.Individual, "15 ulica", PaymentMethod.CashOnDelivery);
            orders.Add(order);

            var result = service.SendToWarehouse(order);

            Assert.False(result);
            Assert.Equal(OrderStatus.ReturnedToClient, order.Status);
        }

        [Fact]
        public void SendToWarehouse_NoDeliveryAddress_SetsError()
        {
            var orders = new List<Order>();
            var service = new OrderService(orders);
            var order = new Order(500m, "book", ClientType.Company, "", PaymentMethod.Card);
            orders.Add(order);

            var result = service.SendToWarehouse(order);

            Assert.False(result);
            Assert.Equal(OrderStatus.Error, order.Status);
        }

        [Fact]
        public void SendToShipping_FromWarehouse_ClosesAfterDelay()
        {
            var orders = new List<Order>();
            var service = new OrderService(orders);
            var order = new Order(1000m, "laptop", ClientType.Individual, "15 ulica", PaymentMethod.Card);
            order.Status = OrderStatus.InWarehouse;
            orders.Add(order);

            var result = service.SendToShipping(order);

            Assert.True(result);
            Assert.Equal(OrderStatus.Closed, order.Status);
        }
    }
}