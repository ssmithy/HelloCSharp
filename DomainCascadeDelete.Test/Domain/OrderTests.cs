using DomainCascadeDelete.Domain;
using DomainCascadeDelete.Test.DummyData;
using FluentAssertions;
namespace DomainCascadeDelete.Test.Domain {
    [TestClass]
    public class OrderTests {
        [TestMethod]
        public void CreateOrder() {
            var order = new Order("1001");

            order.Should().NotBeNull();
            order.Number.Should().Be("1001");
        }

        [TestMethod]
        public void AddProduct() {

            var order = new Order("1001");

            var product = MockData.MockProducts().First();

            order.AddProduct(product);

            order.Items.Should().NotBeNull();
            order.Items.Count.Should().Be(1);
        }

        [TestMethod]
        public void AddTwoProducts() {

            var order = new Order("1001");

            var products = MockData.MockProducts();

            var firstProduct = products.First();
            var secondProduct = products.Skip(1).First();

            order.AddProduct(firstProduct);
            order.Items.Should().NotBeNull();
            order.Items.Count.Should().Be(1);

            order.AddProduct(secondProduct);
            order.Items.Count.Should().Be(2);
        }
    }
}
