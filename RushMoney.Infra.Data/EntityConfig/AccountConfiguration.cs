using RushMoney.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace RushMoney.Infra.Data.EntityConfig
{
    class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(300);


            HasRequired(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId);


        }

    }
}