using DomainCascadeDelete.Domain;
using DomainCascadeDelete.Services;
using DomainCascadeDelete.Test.DummyData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace DomainCascadeDelete.Test.Domain {
    [TestClass]
    public class ProductTests {
        [TestMethod]
        public void CreateProduct() {
            var product = new Product("Test", "This is a test item.");

            product.Should().NotBeNull();
            product.Name.Should().Be("Test");
            product.Description.Should().Be("This is a test item.");
        }

        [TestMethod]
        public async Task ProductMockIsValid() {
            var productService = new Mock<IProductService>();
            productService.Setup(m => m.GetProducts()).Returns(Task.FromResult(MockData.MockProducts()));

            var products = await productService.Object.GetProducts();

            products.FirstOrDefault().Should().NotBeNull();
            products.FirstOrDefault()!.Name.Should().Be("First");

            products.Skip(1).FirstOrDefault().Should().NotBeNull();
            products.Skip(1).FirstOrDefault()!.Name.Should().Be("Second");

            products.Skip(2).FirstOrDefault().Should().NotBeNull();
            products.Skip(2).FirstOrDefault()!.Name.Should().Be("Third");
        }



    }
}
