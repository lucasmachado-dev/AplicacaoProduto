using AplicProduto.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicProduto.Data.Context
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Aplicacao> Aplicacoes { get; set; }
        public DbSet<AplicacaoItem> AplicacaoItens { get; set; }
        public DbSet<AplicacaoItem> Atividades { get; set; }
        public DbSet<CicloProducao> CiclosProducao { get; set; }
        public DbSet<Cultura> Culturas { get; set; }
        public DbSet<Fazenda> Fazendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Talhao> Talhoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string)))) 
            {
                property.SetColumnType("varchar(100)");
            }
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(appDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
            { 
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInsert") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInsert").CurrentValue = DateTime.Now;
                }
                
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInsert").IsModified = false;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
