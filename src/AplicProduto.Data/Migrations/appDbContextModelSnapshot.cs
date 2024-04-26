﻿// <auto-generated />
using System;
using AplicProduto.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AplicProduto.Data.Migrations
{
    [DbContext(typeof(appDbContext))]
    partial class appDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AplicProduto.Business.Models.Aplicacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AtividadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CicloProducaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DataFinal")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Executada")
                        .HasColumnType("bit");

                    b.Property<Guid>("FazendaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SafraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TalhaoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AtividadeId");

                    b.HasIndex("CicloProducaoId");

                    b.HasIndex("FazendaId");

                    b.HasIndex("SafraId");

                    b.HasIndex("TalhaoId");

                    b.ToTable("Aplicacoes", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.AplicacaoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AplicacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("QuantidadeAplicada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AplicacaoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("AplicacaoItens", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Atividade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoAtividade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Atividades", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.CicloProducao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CulturaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("SafraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CulturaId");

                    b.HasIndex("SafraId");

                    b.ToTable("CiclosProducao", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Cultura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeCientifico")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Culturas", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Fazenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Fazendas", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("ValorProduto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Safra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Safras", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Talhao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FazendaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FazendaId");

                    b.ToTable("Talhoes", (string)null);
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Aplicacao", b =>
                {
                    b.HasOne("AplicProduto.Business.Models.Atividade", "Atividade")
                        .WithMany()
                        .HasForeignKey("AtividadeId")
                        .IsRequired();

                    b.HasOne("AplicProduto.Business.Models.CicloProducao", "CicloProducao")
                        .WithMany()
                        .HasForeignKey("CicloProducaoId")
                        .IsRequired();

                    b.HasOne("AplicProduto.Business.Models.Fazenda", "Fazenda")
                        .WithMany()
                        .HasForeignKey("FazendaId")
                        .IsRequired();

                    b.HasOne("AplicProduto.Business.Models.Safra", "Safra")
                        .WithMany()
                        .HasForeignKey("SafraId")
                        .IsRequired();

                    b.HasOne("AplicProduto.Business.Models.Talhao", "Talhao")
                        .WithMany()
                        .HasForeignKey("TalhaoId")
                        .IsRequired();

                    b.Navigation("Atividade");

                    b.Navigation("CicloProducao");

                    b.Navigation("Fazenda");

                    b.Navigation("Safra");

                    b.Navigation("Talhao");
                });

            modelBuilder.Entity("AplicProduto.Business.Models.AplicacaoItem", b =>
                {
                    b.HasOne("AplicProduto.Business.Models.Aplicacao", "Aplicacao")
                        .WithMany("AplicacaoItem")
                        .HasForeignKey("AplicacaoId")
                        .IsRequired();

                    b.HasOne("AplicProduto.Business.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.Navigation("Aplicacao");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AplicProduto.Business.Models.CicloProducao", b =>
                {
                    b.HasOne("AplicProduto.Business.Models.Cultura", "Cultura")
                        .WithMany()
                        .HasForeignKey("CulturaId")
                        .IsRequired();

                    b.HasOne("AplicProduto.Business.Models.Safra", "Safra")
                        .WithMany()
                        .HasForeignKey("SafraId")
                        .IsRequired();

                    b.Navigation("Cultura");

                    b.Navigation("Safra");
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Talhao", b =>
                {
                    b.HasOne("AplicProduto.Business.Models.Fazenda", "Fazenda")
                        .WithMany()
                        .HasForeignKey("FazendaId")
                        .IsRequired();

                    b.Navigation("Fazenda");
                });

            modelBuilder.Entity("AplicProduto.Business.Models.Aplicacao", b =>
                {
                    b.Navigation("AplicacaoItem");
                });
#pragma warning restore 612, 618
        }
    }
}