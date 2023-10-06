using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory
    {
        private readonly string _connectionString;

        public SimpleTraderDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            options.UseSqlServer(_connectionString);

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
