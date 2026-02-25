using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace fundamentosApi.Context
{
    public class AgendaContextFactory : IDesignTimeDbContextFactory<AgendaContext>
    {
        public AgendaContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AgendaContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConexaoPadrao"));

            return new AgendaContext(optionsBuilder.Options);
        }
    }
}
