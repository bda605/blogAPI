using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlogSystem.Model
{
    public partial  class DesignTimeDbContextFactory :
        IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BlogContext>();
            var connectionString = configuration.GetConnectionString("DefaultDatabase");
            builder.UseSqlServer(connectionString);
            return new BlogContext(builder.Options);
        }
    }
}
