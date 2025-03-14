using Xunit;
using OrdersApp;

namespace OrdersApp.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_Initialization_SetsPropertiesCorrectly()
        {
            // Arrange
            decimal amount = 1000m;
            string productName = "Laptop";
            ClientType clientType = ClientType.Individual;
            string deliveryAddress = "123 Main St";
            PaymentMethod paymentMethod = PaymentMethod.Card;

            // Act
            var order = new Order(amount, productName, clientType, deliveryAddress, paymentMethod);

            // Assert
            Assert.Equal(amount, order.Amount);
            Assert.Equal(productName, order.ProductName);
            Assert.Equal(clientType, order.ClientType);
            Assert.Equal(deliveryAddress, order.DeliveryAddress);
            Assert.Equal(paymentMethod, order.PaymentMethod);
            Assert.Equal(OrderStatus.New, order.Status); // Default status
        }

        [Fact]
        public void Order_Initialization_WithEmptyDeliveryAddress_SetsNewStatus()
        {
            // Arrange & Act
            var order = new Order(500m, "Book", ClientType.Company, "", PaymentMethod.CashOnDelivery);

            // Assert
            Assert.Equal("", order.DeliveryAddress);
            Assert.Equal(OrderStatus.New, order.Status); // Still sets to New, error handling comes later
        }
    }
}