using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fornecedores_Model.Features;


namespace Fornecedores_ORM.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("TBSUPPLIER");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(250)").IsRequired();
        }
    }
}
