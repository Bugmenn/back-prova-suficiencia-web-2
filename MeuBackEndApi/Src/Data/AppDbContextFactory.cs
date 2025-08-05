using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MeuBackEndApi.Src.Data;

namespace MeuBackEndApi.Src.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Altere para a mesma string de conexão do seu appsettings.json
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=comandasdb;Username=postgres;Password=27vanzuita");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}