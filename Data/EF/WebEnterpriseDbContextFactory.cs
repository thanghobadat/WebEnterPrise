using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data.EF
{

    public class WebEnterpriseDbContextFactory : IDesignTimeDbContextFactory<WebEnterpriseDbcontext>
    {
        public WebEnterpriseDbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("WebEnterPriseDbContext");

            var optionsBuilder = new DbContextOptionsBuilder<WebEnterpriseDbcontext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new WebEnterpriseDbcontext(optionsBuilder.Options);
        }
    }
}
