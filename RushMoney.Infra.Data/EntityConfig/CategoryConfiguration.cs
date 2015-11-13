using RushMoney.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace RushMoney.Infra.Data.EntityConfig
{
    class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(300);


          

        }

    }
}