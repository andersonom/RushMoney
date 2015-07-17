using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushMoney.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using RushMoney.Infra.Data.EntityConfig;

namespace RushMoney.Infra.Data.Context
{
    public class RushMoneyContext : DbContext
    {
        public RushMoneyContext()
            : base("RushMoney")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new TransactionConfiguration());


        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RegisterDate").CurrentValue = DateTime.Now;


                if (entry.State == EntityState.Modified)
                    entry.Property("RegisterDate").IsModified = false;

            }

            return base.SaveChanges();
        }
    }
}
