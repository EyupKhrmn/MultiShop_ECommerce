using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.DataAccessLayer.Concrate;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost; TrustServerCertificate=True; MultiSubnetFailover=True; Initial Catalog=MultiShopCargoDb; User ID='sa'; Password=reallyStrongPwd123;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }
}