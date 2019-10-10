using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HappyFL.DBFactory
{
    public abstract class DbContextFactory<T> : IDesignTimeDbContextFactory<T> where T : DbContext
    {
        protected readonly DbContextOptionsBuilder<T> optionsBuilder;

        public DbContextFactory()
        {
            var environment = Environment.GetEnvironmentVariable("DB_ENVIRONMENT");

            if (string.IsNullOrEmpty(environment))
                throw new Exception("DB_ENVIRONMENT is not set. Please set the environment variable to either Development or Release.");

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: false);
            var config = builder.Build();
            var connStr = config.GetConnectionString("happyfl-db");
            optionsBuilder = new DbContextOptionsBuilder<T>()
                .UseNpgsql(connStr);
        }

        public abstract T CreateDbContext(params string[] args);
    }
}
