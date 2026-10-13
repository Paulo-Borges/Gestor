using Gestor.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Api.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) {}

        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<OrdemServico> OrdensServico { get; set; } = null!;
        public DbSet<CategoriaServico> CategoriasServico { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdemServico>()
                .HasOne(o => o.Cliente)
                .WithMany(c => OrdensServico)
                .HasForeignKey(o => o.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdemServico>()
               .HasOne(o => o.CategoriaServico)
               .WithMany(c => OrdensServico)
               .HasForeignKey(o => o.CategoriaServicoId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CategoriaServico>().HasData(
                new CategoriaServico { Id = 1, Nome = "Manutenção", Descricao = "Reparos e manutenção geral"},
                new CategoriaServico { Id = 2, Nome = "Instalação", Descricao = "Instalação de equipamentos e sistemas"},
                new CategoriaServico { Id = 3, Nome = "Consultoria", Descricao = "Consultoria técnica e suporte" }
                );
        }
    }
}
