using Microsoft.EntityFrameworkCore;
using System;
using Vueling.Test.Entities;

namespace Vueling.Test.Data
{
    public class VuelingDbContext : DbContext
    {
        public VuelingDbContext(DbContextOptions<VuelingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateEntity>()
                       .ToTable("Rates")
                       .HasKey(r => r.IdRate);
            modelBuilder.Entity<TransactionEntity>()
                      .ToTable("Transactions")
                      .HasKey(t => t.IdTransaction);
        }

        public DbSet<RateEntity> Rates { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
    }
}
