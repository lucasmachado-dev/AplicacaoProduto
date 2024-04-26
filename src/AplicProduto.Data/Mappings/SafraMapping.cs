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
    public class SafraMapping : IEntityTypeConfiguration<Safra>
    {
        public void Configure(EntityTypeBuilder<Safra> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Safras");
        }
    }
}
