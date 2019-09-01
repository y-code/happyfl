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
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            switch (Environment.GetEnvironmentVariable("DB_ENVIRONMENT"))
            {
                case "Development":
                    builder.AddJsonFile("appsettings.Development.json");
                    break;
                case "Release":
                    builder.AddJsonFile("appsettings.Release.json");
                    break;
            }
            var config = builder.Build();
            var connStr = config.GetConnectionString("happyfl-db");
            optionsBuilder = new DbContextOptionsBuilder<T>()
                .UseNpgsql(connStr);
        }

        public abstract T CreateDbContext(params string[] args);
    }
}
