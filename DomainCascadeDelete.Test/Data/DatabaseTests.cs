using DomainCascadeDelete.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DomainCascadeDelete.Test.Data {
    [TestClass]
    public class DatabaseTests {

        [TestInitialize]
        public void CleanDatabase() {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(TestConfig.GetConnectionString());

            var context = new MyDbContext(builder.Options);
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void TestConnection() {

            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(TestConfig.GetConnectionString());

            var context = new MyDbContext(builder.Options);

            context.Database.EnsureCreated();
            context.Database.CanConnect().Should().BeTrue();
        }

        [TestMethod]
        public void TestModelMatchesSchema() {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(TestConfig.GetConnectionString());

            var context = new MyDbContext(builder.Options);

            context.Database.Migrate();

            var tableNames = context.Model.GetEntityTypes()
                .Select(t => t)
                .Distinct()
                .ToList();

            foreach (var table in tableNames) {

                string tableName = table.GetTableName()!;
                string propertiesList = string.Join(",", table.GetProperties()
                    .Select(n => n.GetColumnName()));

                context.Database.ExecuteSqlRaw($"SELECT {propertiesList} FROM {tableName}");
            }
        }

        [TestMethod]
        public void TestMigrations() {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(TestConfig.GetConnectionString());

            var context = new MyDbContext(builder.Options);

            context.Database.Migrate();
        }
    }
}
