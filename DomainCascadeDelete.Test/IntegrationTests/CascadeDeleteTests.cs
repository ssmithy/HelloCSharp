using DomainCascadeDelete.Data;
using DomainCascadeDelete.Domain;
using DomainCascadeDelete.Test.DummyData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCascadeDelete.Test.IntegrationTests {
    [TestClass]
    public class CascadeDeleteTest {

        /// <summary>
        /// Using a DDD approach, test when deleting entities from the aggregate order that 
        /// EF Core will pick up the change and delete the order item
        /// (This should result in the order item being deleted, but the product remaining
        /// </summary>
        [TestMethod]
        public void DeleteOrderItemProductNotDeleted() {

            //setup
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(TestConfig.GetConfiguration().GetConnectionString("CascadeDeleteTest"));
            var context = new MyDbContext(builder.Options);

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            //arrange
            CreateProducts(new MyDbContext(builder.Options));
            CreateAnOrder(new MyDbContext(builder.Options));

            //act
            DeleteOrderItem(new MyDbContext(builder.Options));

            //asset
            CheckOrderItems(new MyDbContext(builder.Options));
        }

        private void CheckOrderItems(MyDbContext context) {

            var orders = context.Set<Order>();
            //get the order
            var savedOrders = orders.Include(x => x.Items).ThenInclude(x => x.Product);
            //test if the order item has gone
            var checkOrder = savedOrders.First();
            //test if products are all stil there
            checkOrder.Items.Should().NotBeNull();
            checkOrder.Items.Count.Should().Be(1);
        }

        private void DeleteOrderItem(MyDbContext context) {

            var orders = context.Set<Order>();
            //get the order
            var savedOrders = orders.Include(x => x.Items).ThenInclude(x => x.Product);
            var mySavedOrder = savedOrders.First();

            mySavedOrder.Items.Should().NotBeNull();
            mySavedOrder.Items.Count.Should().Be(2);

            //delete item from the order
            mySavedOrder.RemoveItem(mySavedOrder.Items.First());

            context.SaveChanges();
        }

        private void CreateAnOrder(MyDbContext context) {

            var products = context.Set<Product>();
            //organise products
            var prod1 = products.First();
            var prod2 = products.Skip(1).First();

            //add an order
            var orders = context.Set<Order>();
            //add items to the order
            var order = new Order("Test");
            order.AddProduct(prod1);
            order.AddProduct(prod2);

            orders.Add(order);

            context.SaveChanges();
        }

        private void CreateProducts(MyDbContext context) {
            //add some products
            var products = context.Set<Product>();
            var newProducts = MockData.MockProducts();

            products.AddRange(newProducts);
            context.SaveChanges();
        }
    }
}
