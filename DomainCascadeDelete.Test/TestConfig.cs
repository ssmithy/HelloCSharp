using DomainCascadeDelete.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DomainCascadeDelete.Test;
internal class TestConfig {
    public static string GetConnectionString() {
        return GetConfiguration().GetConnectionString("IntegrationConnection")!;
    }

    public static IConfiguration GetConfiguration() {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();

        return config;
    }
}
public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext> {
    public MyDbContext CreateDbContext(string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseSqlServer(TestConfig.GetConnectionString());

        return new MyDbContext(optionsBuilder.Options);
    }
}
