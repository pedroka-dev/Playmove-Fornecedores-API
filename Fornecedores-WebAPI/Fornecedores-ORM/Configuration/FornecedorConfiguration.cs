using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fornecedores_Model.Features;


namespace Fornecedores_ORM.Configuration
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("TBFORNECEDOR");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(250)").IsRequired();
        }
    }
}
