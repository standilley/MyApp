using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
namespace MyApp.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produtos");
                entity.HasKey("Id");
                entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Preco).IsRequired().HasPrecision(18, 2);
                entity.Property(p => p.DataCadastro).IsRequired().HasDefaultValueSql("GETUTCDATE()");               
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
