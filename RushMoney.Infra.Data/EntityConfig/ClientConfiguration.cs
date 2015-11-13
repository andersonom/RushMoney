using System.Data.Entity.ModelConfiguration;
using RushMoney.Domain.Entities;

namespace RushMoney.Infra.Data.EntityConfig
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);
                        
            Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Email)
                .IsRequired();
        }
    }
}
