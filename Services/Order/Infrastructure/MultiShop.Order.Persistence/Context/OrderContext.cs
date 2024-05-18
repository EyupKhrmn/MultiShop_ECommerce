using System.Data.Common;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost; TrustServerCertificate=True; MultiSubnetFailover=True; Initial Catalog=MultiShopOrderDb; User ID='sa'; Password=reallyStrongPwd123;");
    }
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}