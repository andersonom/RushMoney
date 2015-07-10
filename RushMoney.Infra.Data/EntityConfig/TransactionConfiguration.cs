using RushMoney.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RushMoney.Infra.Data.EntityConfig
{
   public  class TransactionConfiguration :EntityTypeConfiguration<Transaction>
    {
       public TransactionConfiguration()
       {
           HasKey(p => p.Id);

           Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(300);

           Property(p => p.Value)
               .IsRequired();
               
       }

    }
}
