using Currencyexchange.Models;
using Microsoft.EntityFrameworkCore;

namespace Currencyexchange.DataSource
{
    public class TransactionContext:DbContext
    {
        public TransactionContext(DbContextOptions options)
       : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
