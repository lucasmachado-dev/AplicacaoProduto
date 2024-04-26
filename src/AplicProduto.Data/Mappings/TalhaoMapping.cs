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
    public class TalhaoMapping : IEntityTypeConfiguration<Talhao>
    {
        public void Configure(EntityTypeBuilder<Talhao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Identificacao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Area)
                .IsRequired();

            builder.ToTable("Talhoes");
        }
    }
}
