using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;

public class ContosoPizzaContext : DbContext
{
  public DbSet<Customer> Customers { get; set; } = null!;
  public DbSet<Order> Orders { get; set; } = null!;
  public DbSet<Product> Products { get; set; } = null!;
  public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Username=usmonovdev;Password=2021;Database=shop");
  }
}
