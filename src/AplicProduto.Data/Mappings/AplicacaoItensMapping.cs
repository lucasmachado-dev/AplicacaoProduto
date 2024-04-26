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
    public class AplicacaoItensMapping : IEntityTypeConfiguration<AplicacaoItem>
    {
        public void Configure(EntityTypeBuilder<AplicacaoItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("AplicacaoItens");
        }
    }
}
