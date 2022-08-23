#nullable disable
using Bank.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data;

public class BankDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("server=.;database=Bank;trusted_connection=true;");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<BankAccount> BankAccount { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<GeneralBank> GeneralBank { get; set; }
}