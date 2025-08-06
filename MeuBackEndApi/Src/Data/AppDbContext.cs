using MeuBackEndApi.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuBackEndApi.Src.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comanda>()
                .HasMany(c => c.Produtos)
                .WithMany()
                .UsingEntity(j => j.ToTable("ComandaProdutos"));

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
