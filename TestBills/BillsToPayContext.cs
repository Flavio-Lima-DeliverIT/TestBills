using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TestBills.Models.Entities;

namespace TestBills
{
    public partial class BillsToPayContext : DbContext
    {
        public BillsToPayContext(DbContextOptions<BillsToPayContext> options) : base(options)
        {

        }
        public DbSet<BillsToPay> BillsToPay { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // var connectionString = "User ID = postgres; Password = postgres; Host = localhost; Port = 5432; Database = Db_billstopay; Pooling = true; ";
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(basePath: Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbContextSettings");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }




}
