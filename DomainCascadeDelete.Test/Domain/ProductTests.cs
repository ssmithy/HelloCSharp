using DomainCascadeDelete.Domain;
using FluentAssertions;

namespace DomainCascadeDelete.Test.Domain {
    [TestClass]
    public class ProductTests {
        [TestMethod]
        public void CreateProduct() {
            var product = new Product("Test", "This is a test item.");

            product.Should().NotBeNull();
        }
    }
}
