using DomainCascadeDelete.Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DomainCascadeDelete.Test.Domain {
    [TestClass]
    public class OrderTests {
        [TestMethod]
        public void TestCreateOrder() {
            var order = new Order("1001");

            order.Should().NotBeNull();
            order.Number.Should().Be("1001");
        }

        [TestMethod]
        public void TestAddOrderItem() {



        }




    }
}
