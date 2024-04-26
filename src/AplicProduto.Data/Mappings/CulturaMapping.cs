using AplicProduto.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicProduto.Data.Mappings
{
    internal class CulturaMapping : IEntityTypeConfiguration<Cultura>
    {
        public void Configure(EntityTypeBuilder<Cultura> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.NomeCientifico)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Culturas");
        }
    }
}
