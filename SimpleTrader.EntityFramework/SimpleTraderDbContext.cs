using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContext : DbContext
    {
        public SimpleTraderDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);

            base.OnModelCreating(modelBuilder);
        }
    }
}
