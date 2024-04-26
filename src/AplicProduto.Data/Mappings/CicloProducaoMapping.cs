using AplicProduto.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AplicProduto.Data.Mappings
{
    internal class CicloProducaoMapping : IEntityTypeConfiguration<CicloProducao>
    {
        public void Configure(EntityTypeBuilder<CicloProducao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");
            
            builder.ToTable("CiclosProducao");
        }
    }
}
