using AplicProduto.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AplicProduto.Data.Mappings
{
    internal class FazendaMapping : IEntityTypeConfiguration<Fazenda>
    {
        public void Configure(EntityTypeBuilder<Fazenda> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Fazendas");
        }
    }
}
