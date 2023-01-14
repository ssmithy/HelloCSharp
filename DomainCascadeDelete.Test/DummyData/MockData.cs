using DomainCascadeDelete.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCascadeDelete.Test.DummyData {
    public static class MockData {
        public static IEnumerable<Product> MockProducts() {
            return new List<Product>(new[] {
                new Product("First", "Product"),
                new Product("Second", "Product"),
                new Product("Third", "Product")
            });
        }
    }
}
